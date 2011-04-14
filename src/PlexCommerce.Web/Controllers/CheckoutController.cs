﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
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

        public ActionResult Info(string id)
        {
            var cartItems = (List<CookieCartItem>)Session[id];
            if (cartItems == null) return RedirectToAction("Index", "Cart");
            // if there is no id, then generate one, put cookie data into session and redirect to /checkout/asdkannqwe

            // show email, billing, shipping addresses

            var model = new CheckoutInfoViewModel();

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