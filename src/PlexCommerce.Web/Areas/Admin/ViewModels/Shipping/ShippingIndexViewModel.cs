using System.Collections.Generic;
using System.Web.Mvc;

namespace PlexCommerce.Web.Areas.Admin
{
    public class ShippingIndexViewModel : SharedLayoutViewModel
    {
        public IEnumerable<SelectListItem> AddOptionListItems { get; set; }

        public IList<Country> ShippingCountries { get; set; }
    }
}