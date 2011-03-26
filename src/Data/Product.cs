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

        public virtual ICollection<Category> Categories { get; set; }

        // at least one variant is always available
        public virtual IList<ProductVariant> Variants { get; set; }

        public virtual IList<ProductVariantOption> VariantOptions { get; set; }

        public virtual void SetNewCategories(IEnumerable<Category> newCategories)
        {
            // remove the product from all categies
            foreach (var category in Categories.Where(c => !newCategories.Contains(c)).ToArray())
            {
                category.Products.Remove(this);
                Categories.Remove(category);
            }

            foreach (var category in newCategories)
            {
                category.Products.Add(this);
                Categories.Add(category);
            }
        }
    }
}
