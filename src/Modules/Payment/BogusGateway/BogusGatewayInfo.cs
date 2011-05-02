using System;

namespace PlexCommerce.PaymentModules
{
    public class BogusGatewayInfo : IPaymentModuleInfo
    {
        public string Name
        {
            get { return "Bogus Gateway"; }
        }

        public Type ModuleType
        {
            get { return typeof(BogusGateway); }
        }
    }
}