using FluentNHibernate.Mapping;

namespace PlexCommerce.Mappings
{
    public sealed class ProductVariantMap : ClassMap<ProductVariant>
    {
        public ProductVariantMap()
        {
            Id(x => x.Id, "ProductVariantID");
            Map(x => x.Price).Not.Nullable();

            References(x => x.Product, "ProductID").Not.Nullable().Cascade.All();
            HasMany(x => x.VariantOptionValues).KeyColumn("ProductVariantID").Inverse();
        }
    }
}