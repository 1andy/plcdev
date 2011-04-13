using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace PlexCommerce.Web.Controllers
{
    public abstract class StoreControllerBase : PlexControllerBase
    {
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

        #region Cart Cookie routines

        private const string CartCookieName = "Cart";

        protected CartItems GetCartItemsFromCookie()
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

        protected void SaveCartItemsToCookie(CartItems cartItems)
        {
            string value = string.Join(",", cartItems.Select(ci => string.Format("{0}|{1}", ci.Key, ci.Value)));
            var cookie = new HttpCookie(CartCookieName, value);
            Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// Key is variant ID, value is quantity
        /// </summary>
        protected class CartItems : Dictionary<int, int>
        {
        }

        #endregion
    }
}