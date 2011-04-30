namespace PlexCommerce.Web.Areas.Admin
{
    public class PaymentConfigureViewModel : SharedLayoutViewModel
    {
        public IPaymentModule PaymentMethod { get; set; }

        public PaymentConfigureForm Form { get; set; }
    }
}