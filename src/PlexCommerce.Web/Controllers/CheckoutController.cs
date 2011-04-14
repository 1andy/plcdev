using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using LinqKit;
using NHibernate;

namespace PlexCommerce.Web.Controllers
{
    public class CheckoutController : StoreControllerBase
    {
        private readonly ISession _session;

        #region ctor

        public CheckoutController(ISession session)
            : base(session)
        {
            _session = session;
        }

        #endregion

        public ActionResult Index()
        {
            var cookieItems = GetCookieCart();

            string id = Guid.NewGuid().ToString("N").ToLower();
            Session[id] = cookieItems;
            return RedirectToAction("Info", new { id });
        }

        [HttpGet]
        public ActionResult Info(string id)
        {
            var cartItems = (List<CookieCartItem>)Session[id];
            if (cartItems == null) return RedirectToAction("Index", "Cart");
            // if there is no id, then generate one, put cookie data into session and redirect to /checkout/asdkannqwe

            // show email, billing, shipping addresses

            var model = new CheckoutInfoViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Info(string id, [Bind(Prefix = "Form")] CheckoutInfoForm form)
        {
            //, Expression<Func<CheckoutInfoViewModel, CheckoutAddressForm>> expr
            //, Expression<Func<CheckoutInfoViewModel, CheckoutAddressForm>> expr
            var model = new CheckoutInfoViewModel();

            //Expression<Func<CheckoutInfoViewModel, CheckoutAddressForm>> expr;


            //Func<Expression<Func<CheckoutAddressForm, string>>, Expression<Func<CheckoutInfoViewModel, string>>> aaa =
            //    m => Linq.Expr(((CheckoutInfoViewModel t) => m.Invoke(t).FirstName)).Expand();

            //var a = Linq.Expr((CheckoutInfoViewModel m) => expr.Invoke(m).FirstName).Expand();
            //var a = Linq.Expr((CheckoutAddressForm f) => f.FirstName);

            //Func<Expression<Func<CheckoutAddressForm, string>>, Expression<Func<CheckoutInfoViewModel, string>>> help2 =
            //delegate(Expression<Func<CheckoutAddressForm, string>> m)
            //{
            //    return Linq.Expr(t => m.Invoke(expr.Invoke(Model))).Expand();
            //};

            //Func<Expression<Func<CheckoutAddressForm, string>>, Expression<Func<CheckoutInfoViewModel, string>>> help2 =
            //    m => Linq.Expr((CheckoutInfoViewModel v) => m.Invoke(expr.Invoke(v))).Expand().Expand();

            //expr.Compile()

            return View(model);
        }

        //public ActionResult Options(string id)
        //{
        //    // show select shipping option and select payment option
        //}

        //public ActionResult Complete(string id)
        //{
        //    // show payment option dialog (CC fields, or text + Complete button, or redirect to PayPal or whatever).
        //}

        //public ActionResult Confirm(string id)
        //{
        //    // show page with order #, etc.
        //}
    }
}