using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;

namespace PlexCommerce.Web.Controllers
{
    public class HomeController : StoreControllerBase
    {
        private readonly ISession _session;

        #region ctor

        public HomeController(ISession session)
            : base(session)
        {
            _session = session;
        }

        #endregion

        public ActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Categories = _session.Query<Category>().Where(c => c.ParentCategory == null).ToList();

            return View(model);
        }
    }
}
