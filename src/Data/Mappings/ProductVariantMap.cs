using FluentNHibernate.Mapping;

namespace PlexCommerce.Mappings
{
    public sealed class ProductVariantMap : ClassMap<ProductVariant>
    {
        public ProductVariantMap()
        {
            Id(x => x.Id, "ProductVariantID");
            Map(x => x.Price).CustomSqlType("MONEY").Not.Nullable();
            Map(x => x.Sku).Not.Nullable();

            References(x => x.Product, "ProductID").Not.Nullable();
            HasMany(x => x.VariantOptionValues).KeyColumn("ProductVariantID").Inverse().Cascade.All();
        }
    }
}