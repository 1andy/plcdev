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

        public ActionResult Add()
        {
            var model = new ProductAddViewModel();

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
