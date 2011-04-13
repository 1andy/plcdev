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

            var cartItems = GetCartItemsFromCookie();
            model.Form.CartItems = (from ci in cartItems
                                    where ci.Value > 0
                                    let variant = _session.Get<ProductVariant>(ci.Key)
                                    where variant != null
                                    select new CartFormItem
                                           {
                                               VariantId = variant.Id,
                                               Quantity = ci.Value,
                                               Variant = variant
                                           }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index([Bind(Prefix = "Form")]CartForm form)
        {
            // apply form
            var carItems = new CartItems();
            foreach (var formItem in form.CartItems)
            {
                carItems.Add(formItem.VariantId, formItem.Quantity);
            }

            SaveCartItemsToCookie(carItems);

            return RedirectToAction("Index");
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

            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public ActionResult Checkout(string id)
        //{
        //    var model = new CartCheckoutViewModel();

        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult Checkout([Bind(Prefix = "Form")]CartCheckoutForm form)
        //{
        //    var model = new CartCheckoutViewModel();

        //    if (ModelState.IsValid)
        //    {
        //        using (var transaction = _session.BeginTransaction())
        //        {
        //            // save the data
        //            var customer = new Customer
        //                           {
        //                               Name = form.Name,
        //                               Email = form.Email,
        //                               Orders = new List<Order>()
        //                           };

        //            var order = new Order
        //                        {
        //                            ShippingAddress = new Address
        //                                              {
        //                                                  Address1 = form.ShippingAddress.Address1
        //                                              },
        //                            BillingAddress = new Address
        //                                             {
        //                                                 Address1 = form.BillingAddress.Address1
        //                                             },
        //                            Items = new List<OrderItem>()
        //                        };

        //            customer.AddOrder(order);

        //            var cartItems = GetCartItemsFromCookie();
        //            foreach (var item in cartItems)
        //            {
        //                var variant = _session.Get<ProductVariant>(item.Key);
        //                if (variant == null)
        //                {
        //                    continue;
        //                }

        //                var orderItem = new OrderItem
        //                                {
        //                                    ProductVariant = variant,
        //                                    Quantity = item.Value
        //                                };

        //                order.AddOrderItem(orderItem);
        //            }

        //            _session.Save(customer);

        //            transaction.Commit();
        //        }
        //    }

        //    return View(model);
        //}


    }

    //public class CheckoutController : StoreControllerBase
    //{
    //    private readonly ISession _session;

    //    #region ctor

    //    public CheckoutController(ISession session)
    //        : base(session)
    //    {
    //        _session = session;
    //    }

    //    #endregion

    //    public ActionResult Index(string id)
    //    {
    //        // this is get coming from Cart or whatever

    //        // if there is no id, then generate one, put cookie data into session and redirect to /checkout/asdkannqwe

    //        // show email, billing, shipping addresses
    //    }

    //    public ActionResult Options(string id)
    //    {
    //        // show select shipping option and select payment option
    //    }

    //    public ActionResult Complete(string id)
    //    {
    //        // show payment option dialog (CC fields, or text + Complete button, or redirect to PayPal or whatever).
    //    }

    //    public ActionResult Confirm(string id)
    //    {
    //        // show page with order #, etc.
    //    }
    //}
}