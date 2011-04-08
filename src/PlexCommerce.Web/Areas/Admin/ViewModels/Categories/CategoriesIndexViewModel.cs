using System.Collections.Generic;

namespace PlexCommerce.Web.Areas.Admin
{
    public class CategoriesIndexViewModel : SharedLayoutViewModel
    {
        public IList<Category> Categories { get; set; }
    }
}