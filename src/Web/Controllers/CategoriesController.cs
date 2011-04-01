using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;

namespace PlexCommerce.Web.Controllers
{
    public class CategoriesController : StoreControllerBase
    {
        #region ctor

        public CategoriesController(ISession session)
            : base(session)
        {
        }

        #endregion

        public ActionResult View()
        {
            return View();
        }
    }
}
