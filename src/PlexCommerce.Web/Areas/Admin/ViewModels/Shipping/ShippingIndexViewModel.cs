using System.Collections.Generic;
using System.Web.Mvc;

namespace PlexCommerce.Web.Areas.Admin
{
    public class ShippingIndexViewModel : SharedLayoutViewModel
    {
        //public IList<Country> Countries { get; set; }
        public IEnumerable<SelectListItem> AddOptionListItems { get; set; }
    }
}