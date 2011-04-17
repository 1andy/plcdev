using System.ComponentModel.DataAnnotations;

namespace PlexCommerce
{
    public class ShippingRate
    {
        public virtual int Id { get; set; }

        // name visible to end user
        public virtual string Name { get; set; }

        public virtual Country Country { get; set; }

        // this is nullable
        public virtual StateProvince StateProvince { get; set; }

        public virtual decimal? MinOrderWeight { get; set; }

        public virtual decimal? MaxOrderWeight { get; set; }

        public virtual decimal? MinOrderPrice { get; set; }

        public virtual decimal? MaxOrderPrice { get; set; }

        [Required]
        public virtual decimal ShippingPrice { get; set; }
    }
}