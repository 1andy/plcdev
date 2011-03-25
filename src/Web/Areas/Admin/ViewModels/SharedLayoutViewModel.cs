namespace PlexCommerce.Web.Areas.Admin
{
    public class SharedLayoutViewModel
    {
        public string UserName { get; set; }

        public string StoreName { get; set; }

        #region Model properties allowed to be modified in views

        public string PageTitle { get; set; }

        public string ActiveTab { get; set; }

        public string ActiveSubnav { get; set; }

        #endregion
    }
}