using FluentNHibernate.Mapping;

namespace PlexCommerce.Mappings
{
    public sealed class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id, "ProductID");
            Map(x => x.Name).Not.Nullable();

            HasManyToMany(x => x.Categories).Cascade.All().Inverse().ParentKeyColumn("ProductID").ChildKeyColumn("CategoryID");
            HasMany(x => x.Variants).KeyColumn("ProductID").Inverse();
            HasMany(x => x.VariantOptions).KeyColumn("ProductID").Inverse();
        }
    }
}