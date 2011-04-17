using FluentNHibernate.Mapping;

namespace PlexCommerce.Mappings
{
    public sealed class ShippingRateMap : ClassMap<ShippingRate>
    {
        public ShippingRateMap()
        {
            Id(x => x.Id, "ShippingRateID");
            Map(x => x.Name).Not.Nullable();
            Map(x => x.MinOrderWeight);
            Map(x => x.MaxOrderWeight);
            Map(x => x.MinOrderPrice);
            Map(x => x.MaxOrderPrice);

            References(x => x.Country, "CountryID").Not.Nullable();
            References(x => x.StateProvince, "StateProvinceID");
        }
    }
}