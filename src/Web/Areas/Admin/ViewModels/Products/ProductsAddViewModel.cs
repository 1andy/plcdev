using System.Collections.Generic;
using System.Web.Mvc;

namespace PlexCommerce.Web.Areas.Admin
{
    public class ProductsAddViewModel : SharedLayoutViewModel
    {
        public IEnumerable<SelectListItem> DefaultOptionNameListItems { get; set; }

        public ProductsAddForm AddForm { get; set; }
    }
}