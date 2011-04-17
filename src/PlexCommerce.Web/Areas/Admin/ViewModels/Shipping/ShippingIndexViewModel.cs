using System.Collections.Generic;

namespace PlexCommerce.Web.Areas.Admin
{
    public class ShippingIndexViewModel : SharedLayoutViewModel
    {
        public IList<Country> Countries { get; set; }
    }
}