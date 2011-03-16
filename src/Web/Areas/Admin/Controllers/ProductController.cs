using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace PlexCommerce.Web.Areas.Admin.Controllers
{

    public class ProductController : AdminControllerBase
    {
        public ActionResult Index()
        {
            var model = new ProductIndexViewModel();

            return View(model);
        }
    }
}
