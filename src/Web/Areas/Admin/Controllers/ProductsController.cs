using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace PlexCommerce.Web.Areas.Admin.Controllers
{
    [ValidateInput(false)]
    public class ProductsController : AdminControllerBase
    {
        public ActionResult Index(string q)
        {
            var model = new ProductIndexViewModel();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new ProductsAddViewModel();

            model.AddForm = new ProductsAddForm
                            {
                                Options = new List<ProductOptionName>()
                            };

            model.AddForm.Options.Add(new ProductOptionName() { Name = "Title" });
            model.AddForm.Options.Add(new ProductOptionName() { Name = "Color" });
            model.AddForm.Options.Add(new ProductOptionName() { Name = "Size" });


            return View(model);
        }

        [HttpPost]
        public ActionResult Add([Bind(Prefix = "AddForm")] ProductsAddForm form)
        {
            var model = new ProductsAddViewModel();

            model.AddForm = form;

            return View(model);
        }

        public ActionResult Search()
        {
            var model = new ProductSearchViewModel();

            return View(model);
        }

        public ActionResult Categories()
        {
            var model = new ProductCategoriesViewModel();

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
