namespace PlexCommerce.Web
{
    public class CartFormItem
    {
        public int VariantId { get; set; }

        public int Quantity { get; set; }

        public ProductVariant Variant { get; set; }
    }
}