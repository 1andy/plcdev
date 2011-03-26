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
                Id = product.Id,
                Name = product.Name
            };

            return View(model);
        }

        public ActionResult ViewCategories(int id, int[] categories)
        {
            var product = _session.Get<Product>(id);

            // update categories
            if (Request.HttpMethod == "POST")
            {
                categories = categories ?? new int[0];
                using (var transaction = _session.BeginTransaction())
                {
                    var newCategories = categories.Length > 0 ?
                        _session.Query<Category>().Where(c => categories.Contains(c.Id)) : (IEnumerable<Category>)new Category[0];

                    product.SetNewCategories(newCategories);

                    _session.SaveOrUpdate(product);
                    transaction.Commit();
                }
            }

            var model = new ProductsViewCategoriesViewModel();

            model.ProductCategories = product.Categories;

            // query categories prefetching children 3 levels deep
            model.Categories = _session.Query<Category>().Where(c => c.ParentCategory == null)
                .FetchMany(c => c.ChildCategories)
                .ThenFetchMany(c => c.ChildCategories)
                .ThenFetchMany(c => c.ChildCategories);



            return PartialView(model);
        }
    }
}
