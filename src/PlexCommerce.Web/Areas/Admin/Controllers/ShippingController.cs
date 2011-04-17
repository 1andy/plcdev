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
                            AddOptionListItems = new SelectList(_session.Query<Country>(), "Id", "Name", 840),
                            ShippingCountries = _session.Query<Country>().Where(c => c.ShippingRates.Count() > 0).ToList()
                        };

            return View(model);
        }

        public ActionResult AddRate(int country)
        {
            var model = new ShippingAddRateViewModel { Country = _session.Get<Country>(country) };

            return View(model);
        }
    }
}