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
                               let variant = _session.Get<ProductVariant>(ci.Key)
                               where variant != null
                               select new CartViewCartViewModelCartItem
                                      {
                                          Variant = variant,
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

        [HttpGet]
        public ActionResult Checkout()
        {
            var model = new CartCheckoutViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Checkout([Bind(Prefix = "Form")]CartCheckoutForm form)
        {
            var model = new CartCheckoutViewModel();

            if (ModelState.IsValid)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    // save the data
                    var customer = new Customer
                                   {
                                       Name = form.Name,
                                       Email = form.Email,
                                       Orders = new List<Order>()
                                   };

                    var order = new Order
                                {
                                    ShippingAddress = new Address
                                                      {
                                                          Address1 = form.ShippingAddress.Address1
                                                      },
                                    BillingAddress = new Address
                                                     {
                                                         Address1 = form.BillingAddress.Address1
                                                     },
                                    Items = new List<OrderItem>()
                                };

                    customer.AddOrder(order);

                    var cartItems = GetCartItemsFromCookie();
                    foreach (var item in cartItems)
                    {
                        var variant = _session.Get<ProductVariant>(item.Key);
                        if (variant == null) continue;
                        var orderItem = new OrderItem
                                        {
                                            ProductVariant = variant,
                                            Quantity = item.Value
                                        };

                        order.AddOrderItem(orderItem);
                    }

                    _session.Save(customer);

                    transaction.Commit();
                }
            }

            return View(model);
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