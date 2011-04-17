using System;

namespace PlexCommerce
{
    public class StateProvince
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual Country Country { get; set; }
    }
}