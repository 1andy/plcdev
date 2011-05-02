using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using NHibernate;

namespace PlexCommerce
{
    public class PaymentModuleManager
    {
        private readonly IPaymentModuleInfo[] _paymentModuleInfos;

        public PaymentModuleManager(IPaymentModuleInfo[] paymentModuleInfos)
        {
            _paymentModuleInfos = paymentModuleInfos;
        }

        public IPaymentModuleInfo[] GetAvailablePaymentModules()
        {
            return _paymentModuleInfos;
        }

        public IPaymentModuleInfo GetModuleInfo(string module)
        {
            return _paymentModuleInfos.SingleOrDefault(m => m.ModuleType.Name == module);
        }

        public IPaymentModule CreateModule(string module)
        {
            return (IPaymentModule)Activator.CreateInstance(GetModuleInfo(module).ModuleType);
        }

        public void SaveModuleToMethod(IPaymentModule module, PaymentMethod method)
        {
            var serializer = new XmlSerializer(module.GetType());
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, module);
                method.ModuleSettings = writer.ToString();
                method.ModuleType = module.GetType().Name;
            }
        }

        public IPaymentModule GetModuleFromMethod(PaymentMethod method)
        {
            var moduleInfo = GetModuleInfo(method.ModuleType);
            var serializer = new XmlSerializer(moduleInfo.ModuleType);

            using (var reader = new StringReader(method.ModuleSettings))
            {
                return (IPaymentModule)serializer.Deserialize(reader);
            }
        }
    }
}
