using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace PlexCommerce.Web.Areas.Admin.Controllers
{
    partial class ProductsController
    {
        public ActionResult View(int id)
        {
            var product = _session.Get<Product>(id);

            var model = new ProductsViewViewModel
            {
                Name = product.Name
            };

            // TODO: build a list with <ul><li> scheme
            model.Categories = _session.Query<Category>().Where(c => c.ParentCategory == null)
                .FetchMany(c => c.ChildCategories).ThenFetchMany(c => c.ChildCategories).ThenFetchMany(c => c.ChildCategories);

            return View(model);
        }


        [HttpGet]
        public ActionResult ViewCategories(int id)
        {
            _session.Get<Product>(id);

            var model = new ProductsViewCategoriesViewModel();
            

            return PartialView();
        }
    }
}
