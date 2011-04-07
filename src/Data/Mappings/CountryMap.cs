using FluentNHibernate.Mapping;

namespace PlexCommerce.Mappings
{
    public sealed class CountryMap : ClassMap<Country>
    {
        public CountryMap()
        {
            Id(x => x.Id, "CountryID").GeneratedBy.Assigned();
            Map(x => x.Name).Not.Nullable();

            HasMany(x => x.StateProvinces).KeyColumn("CountryID").Inverse().Cascade.All();
        }
    }
}