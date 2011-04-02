using FluentNHibernate.Mapping;

namespace PlexCommerce.Mappings
{
    public sealed class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.Id, "CustomerID");
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Email).Not.Nullable().Unique();

            HasMany(x => x.Orders).KeyColumn("CustomerID").Inverse().Cascade.All();
        }
    }
}