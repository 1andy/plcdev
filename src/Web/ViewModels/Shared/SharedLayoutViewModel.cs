using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlexCommerce.Web
{
    public class SharedLayoutViewModel
    {
        #region Model properties allowed to be modified in views

        public string PageTitle { get; set; }

        #endregion
    }
}