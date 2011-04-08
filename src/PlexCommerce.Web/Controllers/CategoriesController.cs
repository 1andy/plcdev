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
        private readonly ISession _session;

        #region ctor

        public CategoriesController(ISession session)
            : base(session)
        {
            _session = session;
        }

        #endregion

        public ActionResult View(int id)
        {
            var model = new CategoriesViewViewModel
                        {
                            Category = _session.Get<Category>(id)
                        };

            return View(model);
        }
    }
}
