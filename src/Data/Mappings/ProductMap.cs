using FluentNHibernate.Mapping;

namespace PlexCommerce.Mappings
{
    public sealed class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id, "ProductID");
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Description).Length(10000).Not.Nullable();

            HasManyToMany(x => x.Categories).ParentKeyColumn("ProductID").ChildKeyColumn("CategoryID").Cascade.All().Inverse();
            HasMany(x => x.Variants).KeyColumn("ProductID").Inverse().Cascade.All();
            HasMany(x => x.VariantOptions).KeyColumn("ProductID").Inverse().Cascade.All();
        }
    }
}