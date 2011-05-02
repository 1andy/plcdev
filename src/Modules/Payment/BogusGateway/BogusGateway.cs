namespace PlexCommerce.PaymentModules
{
    public class BogusGateway : IPaymentModule
    {
        public string Name
        {
            get { return "Bogus Gateway"; }
        }
    }
}
