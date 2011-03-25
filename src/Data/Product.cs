using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlexCommerce
{
    public class Product
    {
        public virtual int Id { get; private set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual IList<Category> Categories { get; set; }

        // at least one variant is always available
        public virtual IList<ProductVariant> Variants { get; set; }

        public virtual IList<ProductVariantOption> VariantOptions { get; set; }

        /*public void AddVariant(ProductVariant variant)
        {
            Variants.Add(variant);
            variant.Product = this;
        }

        public void AddVariantOption(ProductVariantOption variantOption)
        {
            VariantOptions.Add(variantOption);
            variantOption.Product = this;
        }*/
    }
}
