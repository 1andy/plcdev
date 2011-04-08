using System;
using System.Collections.Generic;
using NHibernate;

namespace PlexCommerce.Web.Areas.Admin
{
    public class OrderIndexViewModel : SharedLayoutViewModel
    {
        public IList<Order> Orders { get; set; }
    }
}