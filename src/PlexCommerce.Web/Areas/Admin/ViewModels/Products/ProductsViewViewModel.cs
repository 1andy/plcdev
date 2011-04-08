using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NHibernate.Linq;

namespace PlexCommerce.Web.Areas.Admin
{
    public class ProductsViewViewModel : SharedLayoutViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}