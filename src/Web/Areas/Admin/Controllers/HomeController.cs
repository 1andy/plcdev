using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlexCommerce.Web.Areas.Admin.Controllers
{
    public class HomeController : PlexControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
