using System.Collections.Generic;

namespace PlexCommerce.Web
{
    public class HomeIndexViewModel : SharedLayoutViewModel
    {
        public IList<Category> Categories { get; set; }
    }
}