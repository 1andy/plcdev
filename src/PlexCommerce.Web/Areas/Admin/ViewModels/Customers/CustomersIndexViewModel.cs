using System.Collections.Generic;

namespace PlexCommerce.Web.Areas.Admin
{
    public class CustomersIndexViewModel : SharedLayoutViewModel
    {
        public IList<Customer> Customers { get; set; }
    }
}