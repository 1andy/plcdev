namespace PlexCommerce.Web
{
    public class CheckoutInfoViewModel : SharedLayoutViewModel
    {
        public CheckoutInfoForm Form { get; set; }
    }

    public class CheckoutInfoForm
    {
        public string Email { get; set; }

        public CheckoutAddressForm BillingAddress { get; set; }

        public CheckoutAddressForm ShippingAddress { get; set; }

        public bool ShippingIsSameAsBilling { get; set; }
    }

    public class CheckoutAddressForm
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address1 { get; set; }
    }
}