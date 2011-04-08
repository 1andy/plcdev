using System;
using System.Collections.Generic;
using NHibernate.Linq;

namespace PlexCommerce.Web.Areas.Admin
{
    public class ProductsViewCategoriesViewModel
    {
        public IEnumerable<Category> ProductCategories { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}