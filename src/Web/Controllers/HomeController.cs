using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;

namespace PlexCommerce.Web.Controllers
{
    public class HomeController : StoreControllerBase
    {
        #region ctor
        public HomeController(ISession session)
            : base(session)
        {
        }
        #endregion

        public ActionResult Index()
        {
            var model = new HomeIndexViewModel();
            return View(model);
        }
    }
}
