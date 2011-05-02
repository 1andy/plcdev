using FluentNHibernate.Mapping;

namespace PlexCommerce.Mappings
{
    public sealed class PaymentMethodMap : ClassMap<PaymentMethod>
    {
        public PaymentMethodMap()
        {
            Id(x => x.Id, "PaymentMethodID");
            Map(x => x.Name).Not.Nullable();
            Map(x => x.ModuleType).Not.Nullable();
            Map(x => x.ModuleSettings).Length(10000).Not.Nullable();
        }
    }
}