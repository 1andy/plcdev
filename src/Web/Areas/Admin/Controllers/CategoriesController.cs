using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.WebPages;

namespace PlexCommerce.Web.Areas.Admin.Controllers
{
    public class CategoriesController : AdminControllerBase
    {
        public ActionResult Index()
        {
            var model = new CategoriesIndexViewModel();
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new CategoriesAddViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add([Bind(Include = "AddForm")] CategoriesAddViewModel model)
        {
            model.AddForm.Name += "1";

            ModelState.Clear();
            //ModelState.Remove("AddForm.Name");

            return View(model);
        }
    }
}
