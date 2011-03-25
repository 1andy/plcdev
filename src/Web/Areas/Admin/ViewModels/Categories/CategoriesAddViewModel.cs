using System.Collections.Generic;
using System.Web.Mvc;

namespace PlexCommerce.Web.Areas.Admin
{
    public class CategoriesAddViewModel : SharedLayoutViewModel
    {
        public CategoriesAddForm AddForm { get; set; }

        public List<SelectListItem> ParentCategoryIDListItems { get; set; }
    }
}