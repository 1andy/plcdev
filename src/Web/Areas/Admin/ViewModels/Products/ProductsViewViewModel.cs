using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PlexCommerce.Web.Areas.Admin
{
    public class ProductsViewViewModel : SharedLayoutViewModel
    {
        public string Name { get; set; }

        public IEnumerable<SelectListItem> CategoriesListItems { get; set; }
    }
}