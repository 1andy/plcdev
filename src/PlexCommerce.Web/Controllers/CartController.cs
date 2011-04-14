using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;

namespace PlexCommerce.Web.Controllers
{
    public class CartController : StoreControllerBase
    {
        private readonly ISession _session;

        #region ctor

        public CartController(ISession session)
            : base(session)
        {
            _session = session;
        }

        #endregion

        [HttpGet]
        public ActionResult Index()
        {
            var model = new CartIndexViewModel { Form = new CartForm() };

            var cookieItems = GetCookieCart();
            model.Form.CartItems = (from ci in cookieItems
                                    where ci.Quantity > 0
                                    let variant = _session.Get<ProductVariant>(ci.VariantId)
                                    where variant != null
                                    select new CartFormItem
                                           {
                                               VariantId = variant.Id,
                                               Quantity = ci.Quantity,
                                               Variant = variant
                                           }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index([Bind(Prefix = "Form")]CartForm form)
        {
            // apply form
            var cookieItems = new List<CookieCartItem>();
            foreach (var formItem in form.CartItems)
            {
                var cookieItem = new CookieCartItem
                                 {
                                     VariantId = formItem.VariantId,
                                     Quantity = formItem.Quantity
                                 };
                cookieItems.Add(cookieItem);
            }

            SaveCookieCart(cookieItems);

            return RedirectToAction("Index");
        }

        public ActionResult AddToCart(int id)
        {
            var cookieItems = GetCookieCart();

            var itemByVariant = cookieItems.SingleOrDefault(it => it.VariantId == id);
            if (itemByVariant != null)
            {
                itemByVariant.Quantity++;
            }
            else
            {
                cookieItems.Add(
                    new CookieCartItem
                    {
                        VariantId = id,
                        Quantity = 1
                    });
            }

            SaveCookieCart(cookieItems);

            return RedirectToAction("Index");
        }

        ////[HttpGet]
        ////public ActionResult Checkout(string id)
        ////{
        ////    var model = new CartCheckoutViewModel();

        ////    return View(model);
        ////}

        ////[HttpPost]
        ////public ActionResult Checkout([Bind(Prefix = "Form")]CartCheckoutForm form)
        ////{
        ////    var model = new CartCheckoutViewModel();

        ////    if (ModelState.IsValid)
        ////    {
        ////        using (var transaction = _session.BeginTransaction())
        ////        {
        ////            // save the data
        ////            var customer = new Customer
        ////                           {
        ////                               Name = form.Name,
        ////                               Email = form.Email,
        ////                               Orders = new List<Order>()
        ////                           };

        ////            var order = new Order
        ////                        {
        ////                            ShippingAddress = new Address
        ////                                              {
        ////                                                  Address1 = form.ShippingAddress.Address1
        ////                                              },
        ////                            BillingAddress = new Address
        ////                                             {
        ////                                                 Address1 = form.BillingAddress.Address1
        ////                                             },
        ////                            Items = new List<OrderItem>()
        ////                        };

        ////            customer.AddOrder(order);

        ////            var cartItems = GetCookieCart();
        ////            foreach (var item in cartItems)
        ////            {
        ////                var variant = _session.Get<ProductVariant>(item.Key);
        ////                if (variant == null)
        ////                {
        ////                    continue;
        ////                }

        ////                var orderItem = new OrderItem
        ////                                {
        ////                                    ProductVariant = variant,
        ////                                    Quantity = item.Value
        ////                                };

        ////                order.AddOrderItem(orderItem);
        ////            }

        ////            _session.Save(customer);

        ////            transaction.Commit();
        ////        }
        ////    }

        ////    return View(model);
        ////}
    }
}