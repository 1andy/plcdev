using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;
using StructureMap;

namespace PlexCommerce.Web.Areas.Admin.Controllers
{
    public class PaymentController : AdminControllerBase
    {
        private readonly ISession _session;
        private readonly SettingsManager _settings;

        #region ctor

        public PaymentController(ISession session, SettingsManager settings)
            : base(session)
        {
            _session = session;
            _settings = settings;
        }

        #endregion

        public ActionResult Index()
        {
            // TODO: refactor this into service 
            var paymentMethods = ObjectFactory.GetAllInstances<IPaymentMethod>();

            var model = new PaymentIndexViewModel
            {
                AddMethodListItems = from pm in paymentMethods
                                     select new SelectListItem
                                            {
                                                Text = pm.Name,
                                                Value = pm.GetType().Name
                                            },
                PaymentMethods = paymentMethods.Where(pm => _settings.GetValue<bool>("PaymentMethods.Enabled." + pm.GetType().Name)).ToList()
            };

            return View(model);
        }

        public ActionResult Configure(string method)
        {
            var model = new PaymentConfigureViewModel();
            SetupConfigureViewModel(model, method);

            return View(model);
        }

        [HttpPost]
        public ActionResult Configure([Bind(Prefix = "Form")]PaymentConfigureForm form, string method)
        {
            var model = new PaymentConfigureViewModel();
            SetupConfigureViewModel(model, method);

            if (ModelState.IsValid)
            {
                _settings.SetValue("PaymentMethods.Enabled." + model.PaymentMethod.GetType().Name, true);
                TempData["SuccessMessage"] = "Payment method has been activated";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        private void SetupConfigureViewModel(PaymentConfigureViewModel model, string method)
        {
            model.PaymentMethod = ObjectFactory.GetAllInstances<IPaymentMethod>().SingleOrDefault(pm => pm.GetType().Name == method);
            if (model.PaymentMethod == null)
            {
                throw new HttpException(404, "Not found");
            }
        }
    }
}