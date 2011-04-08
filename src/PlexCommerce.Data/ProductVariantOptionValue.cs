namespace PlexCommerce
{
    public class ProductVariantOptionValue
    {
        public virtual int Id { get; private set; }

        public virtual ProductVariant Variant { get; set; }

        public virtual ProductVariantOption Option { get; set; }

        public virtual string Value { get; set; }
    }
}