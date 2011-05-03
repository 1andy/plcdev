using System;

namespace PlexCommerce.PaymentModules
{
    public class CustomPaymentMethodInfo : IPaymentModuleInfo
    {
        public string Name
        {
            get { return "Custom Payment Method"; }
        }

        public Type ModuleType
        {
            get { return typeof(CustomPaymentMethod); }
        }
    }
}