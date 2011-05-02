using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;

namespace PlexCommerce.Web.Areas.Admin.Controllers
{
    public class PaymentController : AdminControllerBase
    {
        private readonly ISession _session;
        private readonly SettingsManager _settings;
        private readonly PaymentModuleManager _paymentModuleManager;

        #region ctor

        public PaymentController(ISession session, SettingsManager settings, PaymentModuleManager paymentModuleManager)
            : base(session)
        {
            _session = session;
            _settings = settings;
            _paymentModuleManager = paymentModuleManager;
        }

        #endregion

        public ActionResult Index()
        {
            var model = new PaymentIndexViewModel
            {
                AddMethodListItems = from pm in _paymentModuleManager.GetAvailablePaymentModules()
                                     select new SelectListItem
                                            {
                                                Text = pm.Name,
                                                Value = pm.ModuleType.Name
                                            },
                PaymentMethods = _session.Query<PaymentMethod>().ToList()
            };

            return View(model);
        }

        public ActionResult Configure(int? id, string module)
        {
            var model = new PaymentConfigureViewModel();
            SetupConfigureViewModel(model, module);

            return View(model);
        }

        [HttpPost]
        public ActionResult Configure([Bind(Prefix = "Form")]PaymentConfigureForm form, string module)
        {
            var model = new PaymentConfigureViewModel();
            SetupConfigureViewModel(model, module);

            if (ModelState.IsValid)
            {
                var paymentModule = _paymentModuleManager.CreateModule(module);
                //// TODO: setup paymentModule from form values

                var method = new PaymentMethod
                {
                    Name = paymentModule.Name
                };

                _paymentModuleManager.SaveModuleToMethod(paymentModule, method);

                using (var transaction = _session.BeginTransaction())
                {
                    _session.Save(method);
                    transaction.Commit();
                }

                TempData["SuccessMessage"] = "Payment method has been activated";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        private void SetupConfigureViewModel(PaymentConfigureViewModel model, string module)
        {
            model.ModuleInfo = _paymentModuleManager.GetModuleInfo(module);
            if (model.ModuleInfo == null)
            {
                throw new HttpException(404, "Not found");
            }
        }
    }
}