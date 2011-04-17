using System;
using System.Collections.Generic;

namespace PlexCommerce
{
    public class StateProvince
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual Country Country { get; set; }

        public virtual IList<ShippingRate> ShippingRates { get; set; }
    }
}