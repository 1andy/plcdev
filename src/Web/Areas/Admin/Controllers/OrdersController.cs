using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlexCommerce.Web.Areas.Admin.Controllers
{
    public class OrdersController : AdminControllerBase
    {
        public ActionResult Index()
        {
            var model = new OrderIndexViewModel();
            return View(model);
        }
    }
}
