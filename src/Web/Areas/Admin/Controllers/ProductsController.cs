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
    [ValidateInput(false)]
    public partial class ProductsController : AdminControllerBase
    {
        private readonly ISession _session;

        public ProductsController(ISession session)
        {
            _session = session;
        }

        public ActionResult Index(string q)
        {
            var model = new ProductsIndexViewModel { Products = _session.Query<Product>() };

            return View(model);
        }

        #region Add

        [HttpGet]
        public ActionResult Add()
        {
            var model = new ProductsAddViewModel { AddForm = new ProductsAddForm() };

            SetupAddViewModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Add([Bind(Prefix = "AddForm")] ProductsAddForm form)
        {
            var model = new ProductsAddViewModel { AddForm = form };

            if (ModelState.IsValid)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    var product = new Product
                                  {
                                      Name = form.Name,
                                      Description = form.Description ?? string.Empty
                                  };

                    var primaryVariant = new ProductVariant
                                         {
                                             Price = form.Price.Value,
                                             Sku = form.Sku ?? string.Empty,
                                             Product = product
                                         };

                    product.Variants = new[] { primaryVariant };

                    _session.Save(product);
                    transaction.Commit();
                    return RedirectToAction("View", new { id = product.Id });
                }
            }

            SetupAddViewModel(model);
            return View(model);
        }

        private static void SetupAddViewModel(ProductsAddViewModel model)
        {
            var defaultItems = new[] { "Title", "Color", "Size" };

            model.DefaultOptionNameListItems = (from it in defaultItems
                                                select new SelectListItem
                                                       {
                                                           Value = it,
                                                           Text = it
                                                       }).ToList();

            if (model.AddForm.Options == null)
            {
                model.AddForm.Options = new List<ProductOptionData>();
            }

            var options = model.AddForm.Options;

            // make sure we have 3 options
            if (options.Count < 1)
            {
                options.Add(new ProductOptionData { Disabled = true });
            }

            if (options.Count < 2)
            {
                options.Add(new ProductOptionData { Disabled = true });
            }

            if (options.Count < 3)
            {
                options.Add(new ProductOptionData { Disabled = true });
            }
        }

        #endregion

        public ActionResult Search()
        {
            var model = new ProductsSearchViewModel();

            return View(model);
        }
    }
}
