using FluentNHibernate.Mapping;

namespace PlexCommerce.Mappings
{
    public sealed class OrderItemMap : ClassMap<OrderItem>
    {
        public OrderItemMap()
        {
            Id(x => x.Id, "OrderItemID");
            Map(x => x.Quantity).Not.Nullable();

            References(x => x.Order, "OrderID").Not.Nullable();
            References(x => x.ProductVariant, "ProductVariantID");
        }
    }
}