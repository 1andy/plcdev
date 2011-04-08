using System.ComponentModel.DataAnnotations;

namespace PlexCommerce.Web.Areas.Admin
{
    public class CategoriesAddForm
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int? ParentCategoryID { get; set; }
    }
}