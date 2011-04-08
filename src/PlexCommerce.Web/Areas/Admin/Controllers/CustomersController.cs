using System.Linq;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;

namespace PlexCommerce.Web.Areas.Admin.Controllers
{
    public class CustomersController : AdminControllerBase
    {
        private readonly ISession _session;

        #region ctor

        public CustomersController(ISession session)
            : base(session)
        {
            _session = session;
        }

        #endregion

        public ActionResult Index()
        {
            var model = new CustomersIndexViewModel
                        {
                            Customers = _session.Query<Customer>().ToList()
                        };

            return View(model);
        }

        public ActionResult View(int id)
        {
            var model = new CustomersViewViewModel
                        {
                            Customer = _session.Get<Customer>(id)
                        };

            return View(model);
        }
    }
}