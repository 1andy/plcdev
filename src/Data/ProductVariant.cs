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

    public class ProductVariantOption
    {
        public virtual int Id { get; private set; }

        public virtual string Name { get; set; }

        public virtual Product Product { get; set; }

        public virtual IList<ProductVariantOptionValue> VariantOptionValues { get; set; }
    }

    public class ProductVariantOptionValue
    {
        public virtual int Id { get; private set; }

        public virtual ProductVariantOption Option { get; set; }

        public virtual ProductVariant Variant { get; set; }

        public virtual string Value { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var t = obj as ProductVariantOptionValue;
            if (t == null)
                return false;
            if (Option == t.Option && Variant == t.Variant)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return (Option.Id + Variant.Id).GetHashCode();
        }
    }
}
