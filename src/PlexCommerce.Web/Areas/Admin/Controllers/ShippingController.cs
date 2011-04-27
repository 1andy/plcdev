using System;
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
            var model = new ShippingAddRateViewModel();
            SetupAddRateViewModel(model, country);
            return View(model);
        }

        [HttpPost]
        public ActionResult AddRate([Bind(Prefix = "Form")]ShippingAddRateForm form, int country)
        {
            if (ModelState.IsValid)
            {
                var rate = new ShippingRate
                {
                    Name = form.Name,
                    Country = _session.Load<Country>(country),
                    ShippingPrice = form.ShippingPrice
                };

                switch (form.Type)
                {
                    case "weight":
                        rate.MinOrderWeight = form.MinWeight;
                        rate.MaxOrderWeight = form.MaxWeight;
                        break;
                    case "price":
                        rate.MinOrderPrice = form.MinPrice;
                        rate.MaxOrderPrice = form.MaxPrice;
                        break;
                    default:
                        throw new NotSupportedException();
                }

                _session.Save(rate);

                TempData["SuccessMessage"] = "Shipping rate has been added";
                return RedirectToAction("Index");
            }

            var model = new ShippingAddRateViewModel();
            SetupAddRateViewModel(model, country);
            return View(model);
        }

        private void SetupAddRateViewModel(ShippingAddRateViewModel model, int country)
        {
            model.Country = _session.Get<Country>(country);
        }
    }
}