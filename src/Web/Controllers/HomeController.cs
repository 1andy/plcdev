using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlexCommerce.Web.Controllers
{
    public class HomeController : PlexControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
