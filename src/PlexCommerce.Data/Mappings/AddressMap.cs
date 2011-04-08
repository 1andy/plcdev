using FluentNHibernate.Mapping;

namespace PlexCommerce.Mappings
{
    public sealed class AddressMap : ClassMap<Address>
    {
        public AddressMap()
        {
            Id(x => x.Id, "AddressID");
            Map(x => x.Address1).Not.Nullable();
        }
    }
}