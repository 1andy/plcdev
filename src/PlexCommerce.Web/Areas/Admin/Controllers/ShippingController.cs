using System.Linq;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;

namespace PlexCommerce.Web.Areas.Admin.Controllers
{
    public class ShippingController : AdminControllerBase
    {
        private readonly ISession _session;

        #region ctor

        public ShippingController(ISession session)
            : base(session)
        {
            _session = session;
        }

        #endregion

        public ActionResult Index()
        {
            var model = new ShippingIndexViewModel
                        {
                            AddOptionListItems = new SelectList(_session.Query<Country>(), "Id", "Name", 840)
                            //,Countries = _session.Query<Country>().Where(c => c.Active).OrderBy(c => c.Name).ToList()
                        };

            return View(model);
        }
    }
}