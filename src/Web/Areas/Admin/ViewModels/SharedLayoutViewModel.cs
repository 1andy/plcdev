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

        #region Model properties allowed to be modified in views

        public string Title { get; set; }
        public string ActiveTab { get; set; }
        public string ActiveSubnav { get; set; }

        #endregion
    }

    public class ProductIndexViewModel : SharedLayoutViewModel
    {

    }

    public class ProductAddViewModel : SharedLayoutViewModel
    {

    }

    public class ProductSearchViewModel : SharedLayoutViewModel
    {

    }
}