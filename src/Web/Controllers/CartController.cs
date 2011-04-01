using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;

namespace PlexCommerce.Web.Controllers
{
    public class CartController : StoreControllerBase
    {
        private const string CartCookieName = "Cart";

        private readonly ISession _session;

        #region ctor

        public CartController(ISession session)
            : base(session)
        {
            _session = session;
        }

        #endregion

        public ActionResult ViewCart()
        {
            var model = new CartViewCartViewModel();

            var cartItems = GetCartItemsFromCookie();

            model.CartItems = (from ci in cartItems
                               where ci.Value > 0
                               select new CartViewCartViewModelCartItem
                                      {
                                          Variant = _session.Get<ProductVariant>(ci.Key),
                                          Quantity = ci.Value
                                      }).ToList();

            return View(model);
        }

        public ActionResult AddToCart(int id)
        {
            var cartItems = GetCartItemsFromCookie();

            if (cartItems.ContainsKey(id))
            {
                cartItems[id]++;
            }
            else
            {
                cartItems[id] = 1;
            }

            SaveCartItemsToCookie(cartItems);

            return RedirectToAction("ViewCart");
        }

        #region Cookie routines

        private CartItems GetCartItemsFromCookie()
        {
            var cookie = Request.Cookies[CartCookieName];
            if (cookie == null || cookie.Value.Length == 0)
            {
                return new CartItems();
            }

            var cartItems = new CartItems();

            foreach (string value in cookie.Value.Split(','))
            {
                var items = value.Split('|');
                cartItems.Add(int.Parse(items[0]), int.Parse(items[1]));
            }

            return cartItems;
        }

        private void SaveCartItemsToCookie(CartItems cartItems)
        {
            string value = string.Join(",", cartItems.Select(ci => string.Format("{0}|{1}", ci.Key, ci.Value)));
            var cookie = new HttpCookie(CartCookieName, value);
            Response.Cookies.Add(cookie);
        }

        #endregion

        private class CartItems : Dictionary<int, int>
        {
        }
    }
}