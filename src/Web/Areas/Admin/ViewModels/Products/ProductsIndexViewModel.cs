using System.Collections.Generic;

namespace PlexCommerce.Web.Areas.Admin
{
    public class ProductsIndexViewModel : SharedLayoutViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}