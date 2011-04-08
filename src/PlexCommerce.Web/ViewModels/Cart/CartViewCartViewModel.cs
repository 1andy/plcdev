using System.Collections.Generic;

namespace PlexCommerce.Web
{
    public class CartViewCartViewModel : SharedLayoutViewModel
    {
        public IList<CartViewCartViewModelCartItem> CartItems { get; set; }
    }
}