using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using NHibernate;

namespace PlexCommerce.Web.Areas.Admin.Controllers
{
    [ValidateInput(false)]
    public class ProductsController : AdminControllerBase
    {
        private readonly ISession _session;

        public ProductsController(ISession session)
        {
            _session = session;
        }


        public ActionResult Index(string q)
        {
            var model = new ProductIndexViewModel();

            return View(model);
        }

        //        public ActionResult Test()
        //        {
        //var model = new OptionsViewModel();

        //// for DropDownListFor
        //model.AgentTypeListItems = new[]
        //{
        //    new SelectListItem { Text = "1", Value = "1" }, 
        //    new SelectListItem { Text = "2", Value = "2" },
        //    new SelectListItem { Text = "3", Value = "3" },
        //};

        //// 1 dropdown in the model
        //model.AgentType = "2";

        //// 3 dropdowns in array (setting AgentType does not affect)
        //model.AgentTypes = new[] { "3", "2", "1" };

        //return View(model);
        //        }



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
                model.AddForm.Options = new List<ProductOptionName>();
            }

            var options = model.AddForm.Options;

            // make sure we have 3 options
            if (options.Count < 1)
            {
                options.Add(new ProductOptionName { Disabled = true });
            }

            if (options.Count < 2)
            {
                options.Add(new ProductOptionName { Disabled = true });
            }

            if (options.Count < 3)
            {
                options.Add(new ProductOptionName { Disabled = true });
            }
        }

        #endregion

        public ActionResult Search()
        {
            var model = new ProductSearchViewModel();

            return View(model);
        }

        ////protected override void SetAdditionalViewModelData(object modelObject)
        ////{
        ////    var model = (SharedLayoutViewModel)modelObject;
        ////    model.ActiveTab = "products";
        ////    base.SetAdditionalViewModelData(model);
        ////}
    }
}
