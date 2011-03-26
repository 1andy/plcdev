using FluentNHibernate.Mapping;

namespace PlexCommerce.Mappings
{
    public sealed class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id, "CategoryID");
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Description).Length(10000).Not.Nullable();

            References(x => x.ParentCategory, "ParentCategoryID");
            HasMany(x => x.ChildCategories).KeyColumn("ParentCategoryID").Inverse().Cascade.All();
            HasManyToMany(x => x.Products).AsSet().Table("CategoryProduct").ChildKeyColumn("ProductID").ParentKeyColumn("CategoryID").Cascade.All();
        }
    }
}