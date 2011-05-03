namespace PlexCommerce.PaymentModules
{
    public class CustomPaymentMethod : IPaymentModule
    {
        public string Name
        {
            get { return "Custom Payment Method"; }
        }
    }
}
