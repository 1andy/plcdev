using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;

namespace PlexCommerce.Web.Areas.Admin.Controllers
{
    public class RegionsController : AdminControllerBase
    {
        private readonly ISession _session;

        #region ctor

        public RegionsController(ISession session)
            : base(session)
        {
            _session = session;
        }

        #endregion

        public ActionResult Index()
        {
            var model = new RegionsIndexViewModel();

            return View(model);
        }
    }
}