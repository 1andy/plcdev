using System;
using System.Collections.Generic;

namespace PlexCommerce
{
    public class Order
    {
        public virtual int Id { get; private set; }

        public virtual Customer Customer { get; set; }

        public virtual IList<OrderItem> Items { get; set; }

        public virtual Address ShippingAddress { get; set; }

        public virtual Address BillingAddress { get; set; }

        public virtual void AddOrderItem(OrderItem orderItem)
        {
            Items.Add(orderItem);
            orderItem.Order = this;
        }
    }
}