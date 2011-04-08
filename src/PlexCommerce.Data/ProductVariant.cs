using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlexCommerce
{
    public class ProductVariant
    {
        public virtual int Id { get; private set; }

        public virtual decimal Price { get; set; }

        public virtual string Sku { get; set; }

        public virtual Product Product { get; set; }

        public virtual IList<ProductVariantOptionValue> VariantOptionValues { get; set; }

        // measurements for this variant (for shipping)

        // taxing options

        // old_price
    }
}
