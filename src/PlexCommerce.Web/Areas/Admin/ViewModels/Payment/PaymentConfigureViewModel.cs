namespace PlexCommerce.Web.Areas.Admin
{
    public class PaymentConfigureViewModel : SharedLayoutViewModel
    {
        public IPaymentModuleInfo ModuleInfo { get; set; }

        public PaymentConfigureForm Form { get; set; }
    }
}