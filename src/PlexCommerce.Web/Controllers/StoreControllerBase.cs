using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace PlexCommerce.Web.Controllers
{
    public abstract class StoreControllerBase : PlexControllerBase
    {
        private const string CartCookieName = "Cart";
        private readonly ISession _session;

        protected StoreControllerBase(ISession session)
        {
            _session = session;
        }

        protected override void SetAdditionalViewModelData(object model)
        {
            var sharedLayoutViewModel = model as SharedLayoutViewModel;
            if (sharedLayoutViewModel != null)
            {
                sharedLayoutViewModel.StoreName = "Jama Stuff";
            }

            base.SetAdditionalViewModelData(model);
        }

        #region CookieCart

        protected List<CookieCartItem> GetCookieCart()
        {
            var cartItems = new List<CookieCartItem>();

            var cookie = Request.Cookies[CartCookieName];
            if (cookie != null && cookie.Value.Length > 0)
            {
                foreach (string value in cookie.Value.Split(','))
                {
                    var values = value.Split('|');
                    var item = new CookieCartItem
                               {
                                   VariantId = int.Parse(values[0]),
                                   Quantity = int.Parse(values[1])
                               };

                    cartItems.Add(item);
                }
            }

            return cartItems;
        }

        protected void SaveCookieCart(IEnumerable<CookieCartItem> items)
        {
            string value = string.Join(",", items.Select(ci => string.Format("{0}|{1}", ci.VariantId, ci.Quantity)));
            var cookie = new HttpCookie(CartCookieName, value);
            Response.Cookies.Add(cookie);
        }

        protected class CookieCartItem
        {
            public int VariantId { get; set; }

            public int Quantity { get; set; }
        }

        #endregion
    }
}