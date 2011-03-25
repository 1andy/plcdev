using FluentNHibernate.Mapping;

namespace PlexCommerce.Mappings
{
    public sealed class ProductVariantOptionValueMap : ClassMap<ProductVariantOptionValue>
    {
        public ProductVariantOptionValueMap()
        {
            Id(x => x.Id, "ProductVariantOptionValue");
            Map(x => x.Value);

            References(x => x.Option, "ProductVariantOptionID").Not.Nullable().UniqueKey("OptionVariant");
            References(x => x.Variant, "ProductVariantID").Not.Nullable().UniqueKey("OptionVariant");
        }
    }
}