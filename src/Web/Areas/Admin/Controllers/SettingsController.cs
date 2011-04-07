using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;

namespace PlexCommerce.Web.Areas.Admin.Controllers
{
    public class SettingsController : AdminControllerBase
    {
        private readonly ISession _session;

        #region ctor

        public SettingsController(ISession session)
            : base(session)
        {
            _session = session;
        }

        #endregion

        public ActionResult Index()
        {
            var model = new SettingsIndexViewModel();

            return View(model);
        }
    }
}
