namespace PlexCommerce.Web
{
    public class CheckoutInfoForm
    {
        public string Email { get; set; }

        public CheckoutAddressForm BillingAddress { get; set; }

        public CheckoutAddressForm ShippingAddress { get; set; }

        public bool ShippingIsSameAsBilling { get; set; }
    }
}