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
        public IList<Category> Categories { get; set; }
    }

    public class CategoriesAddViewModel : SharedLayoutViewModel
    {
        public CategoriesAddForm AddForm { get; set; }

        public List<SelectListItem> ParentCategoryIDListItems { get; set; }
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

    //public class OptionsViewModel
    //{
    //    public string AgentType { get; set; }
    //    public string[] AgentTypes { get; set; }
    //    public SelectListItem[] AgentTypeListItems { get; set; }
    //}

    public class ProductsAddViewModel : SharedLayoutViewModel
    {
        public IEnumerable<SelectListItem> DefaultOptionNameListItems { get; set; }

        public ProductsAddForm AddForm { get; set; }
    }

    public class ProductsAddForm
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal? Price { get; set; }

        public string Description { get; set; }

        public string Sku { get; set; }

        public IList<ProductOptionName> Options { get; set; }
    }

    public class ProductOptionName
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool Disabled { get; set; }
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