using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using NHibernate;

namespace PlexCommerce.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminControllerBase
    {
        #region ctor

        public HomeController(ISession session) : base(session)
        {
        }

        #endregion

        public ActionResult Index()
        {
            var model = new SharedLayoutViewModel();

            return View(model);
        }

        ////        protected override void SetAdditionalViewModelData(object modelObject)
        //        {
        //            var model = (SharedLayoutViewModel)modelObject;
        //            model.ActiveTab = "home";
        //            base.SetAdditionalViewModelData(model);
        //        }
    }
}
