using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlexCommerce
{
    public class Country
    {
        /// <summary>
        /// That is numeric ISO code of the country
        /// </summary>
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual bool Active { get; set; }

        public virtual IList<StateProvince> StateProvinces { get; set; }

        public virtual IList<ShippingRate> ShippingRates { get; set; }
    }
}
