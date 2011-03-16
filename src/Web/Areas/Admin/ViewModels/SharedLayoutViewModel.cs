using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlexCommerce.Web.Areas.Admin
{
    public class SharedLayoutViewModel
    {
        public string UserName { get; set; }
        public string StoreName { get; set; }
        public string ActiveTab { get; set; }
    }

    public class ProductIndexViewModel : SharedLayoutViewModel
    {

    }
}