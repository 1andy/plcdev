using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace PlexCommerce.Web.Areas.Admin.Controllers
{

    public class ProductsController : AdminControllerBase
    {
        public ActionResult Index()
        {
            var model = new ProductIndexViewModel();

            return View(model);
        }


        protected override void SetAdditionalViewModelData(object modelObject)
        {
            var model = (SharedLayoutViewModel)modelObject;
            model.ActiveTab = "products";
            base.SetAdditionalViewModelData(model);
        }
    }
}
