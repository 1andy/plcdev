using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlexCommerce.Web.Areas.Admin
{
    public class ProductsAddForm
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal? Price { get; set; }

        public string Description { get; set; }

        public string Sku { get; set; }

        public IList<ProductOptionData> Options { get; set; }
    }
}