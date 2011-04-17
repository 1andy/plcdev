using FluentNHibernate.Mapping;

namespace PlexCommerce.Mappings
{
    public sealed class StateProvinceMap : ClassMap<StateProvince>
    {
        public StateProvinceMap()
        {
            Id(x => x.Id, "StateProvinceID");
            Map(x => x.Name).Not.Nullable();

            References(x => x.Country, "CountryID").Not.Nullable();
            HasMany(x => x.ShippingRates).KeyColumn("StateProvinceID").Inverse().Cascade.All();
        }
    }
}