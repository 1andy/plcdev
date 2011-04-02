using FluentNHibernate.Mapping;

namespace PlexCommerce.Mappings
{
    public sealed class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(x => x.Id, "OrderID");

            HasMany(x => x.Items).KeyColumn("OrderID").Inverse().Cascade.All();
            References(x => x.Customer, "CustomerID").Not.Nullable();
            References(x => x.ShippingAddress, "ShippingAddressID").Cascade.All();
            References(x => x.BillingAddress, "BillingAddressID").Cascade.All();
        }
    }
}