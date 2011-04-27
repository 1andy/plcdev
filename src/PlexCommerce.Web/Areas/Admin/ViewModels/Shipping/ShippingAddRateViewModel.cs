using System.ComponentModel.DataAnnotations;

namespace PlexCommerce.Web.Areas.Admin
{
    public class ShippingAddRateViewModel : SharedLayoutViewModel
    {
        public Country Country { get; set; }

        public ShippingAddRateForm Form { get; set; }
    }

    public class ShippingAddRateForm
    {
        [Required]
        public string Type { get; set; }

        public string Name { get; set; }

        public decimal? MinWeight { get; set; }

        public decimal? MaxWeight { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public decimal ShippingPrice { get; set; }
    }
}