using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace PlexCommerce.Web.Areas.Admin.Controllers
{

    public class HomeController : AdminControllerBase
    {
        public ActionResult Index()
        {
            var model = new SharedLayoutViewModel();

            return View(model);
        }

        protected override void SetAdditionalViewModelData(object modelObject)
        {
            var model = (SharedLayoutViewModel)modelObject;
            model.ActiveTab = "home";
            base.SetAdditionalViewModelData(model);
        }
    }
}
