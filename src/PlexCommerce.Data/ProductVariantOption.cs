using System.Collections.Generic;

namespace PlexCommerce
{
    public class ProductVariantOption
    {
        public virtual int Id { get; private set; }

        public virtual string Name { get; set; }

        public virtual Product Product { get; set; }

        public virtual IList<ProductVariantOptionValue> VariantOptionValues { get; set; }
    }
}