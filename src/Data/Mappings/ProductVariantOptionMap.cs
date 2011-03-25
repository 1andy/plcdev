using FluentNHibernate.Mapping;

namespace PlexCommerce.Mappings
{
    public sealed class ProductVariantOptionMap : ClassMap<ProductVariantOption>
    {
        public ProductVariantOptionMap()
        {
            Id(x => x.Id, "ProductVariantOptionID");
            Map(x => x.Name).Not.Nullable();

            References(x => x.Product, "ProductID").Not.Nullable();
            HasMany(x => x.VariantOptionValues).KeyColumn("ProductVariantOptionID").Inverse().Cascade.All();
        }
    }
}