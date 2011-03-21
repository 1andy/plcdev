using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

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

    public class CategoriesIndexViewModel : SharedLayoutViewModel
    {
    }

    public class CategoriesAddViewModel : SharedLayoutViewModel
    {
        public CategoriesAddForm AddForm { get; set; }

        public List<SelectListItem> ParentCategoryIDSelectList { get; set; }
    }

    public class CategoriesAddForm
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int? ParentCategoryID { get; set; }
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

    public class ProductCategoriesViewModel : SharedLayoutViewModel
    {
        public IEnumerable<ProductCategoryData> Categories { get; set; }
    }

    public class ProductCategoryData
    {
        public int CategoryID { get; set; }

        public string Name { get; set; }
    }
}