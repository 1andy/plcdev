using FluentNHibernate.Mapping;

namespace PlexCommerce.Mappings
{
    public sealed class ProductVariantOptionValueMap : ClassMap<ProductVariantOptionValue>
    {
        public ProductVariantOptionValueMap()
        {
            Id(x => x.Id, "ProductVariantOptionValue");
            Map(x => x.Value);

            References(x => x.Option).Not.Nullable().Column("ProductVariantOptionID").UniqueKey("OptionVariant").Cascade.All();
            References(x => x.Variant).Not.Nullable().Column("ProductVariantID").UniqueKey("OptionVariant").Cascade.All();
        }
    }
}