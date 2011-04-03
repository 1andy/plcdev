using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;

namespace PlexCommerce.Web.Areas.Admin.Controllers
{
    public class OrdersController : AdminControllerBase
    {
        private readonly ISession _session;

        #region ctor

        public OrdersController(ISession session)
            : base(session)
        {
            _session = session;
        }

        #endregion

        public ActionResult Index()
        {
            var model = new OrderIndexViewModel
                        {
                            Orders = _session.Query<Order>().ToList()
                        };

            return View(model);
        }

        public ActionResult View(int id)
        {
            var model = new OrderViewViewModel();
            model.Order = _session.Get<Order>(id);

            return View(model);
        }
    }
}
