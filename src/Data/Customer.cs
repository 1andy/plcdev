using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlexCommerce
{
    public class Customer
    {
        public virtual int Id { get; private set; }

        public virtual string Name { get; set; }

        public virtual string Email { get; set; }

        public virtual IList<Order> Orders { get; set; }

        public virtual void AddOrder(Order order)
        {
            Orders.Add(order);
            order.Customer = this;
        }
    }
}
