using System.Collections.Generic;
using System.Web.Mvc;

namespace PlexCommerce.Web.Areas.Admin
{
    public class PaymentIndexViewModel : SharedLayoutViewModel
    {
        public IEnumerable<SelectListItem> AddMethodListItems { get; set; }

        public IList<PaymentMethod> PaymentMethods { get; set; }
    }
}