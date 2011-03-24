using FluentNHibernate.Mapping;

namespace PlexCommerce.Mappings
{
    public sealed class ProductVariantOptionMap : ClassMap<ProductVariantOption>
    {
        public ProductVariantOptionMap()
        {
            Id(x => x.Id, "ProductVariantOptionID");
            Map(x => x.Name).Not.Nullable();

            References(x => x.Product).Not.Nullable().Column("ProductID").Cascade.All();
            HasMany(x => x.VariantOptionValues).KeyColumn("ProductVariantOptionID").Inverse();
        }
    }
}