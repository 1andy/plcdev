namespace PlexCommerce.Web.Areas.Admin
{
    public class PaymentConfigureViewModel : SharedLayoutViewModel
    {
        public IPaymentMethod PaymentMethod { get; set; }

        public PaymentConfigureForm Form { get; set; }
    }
}