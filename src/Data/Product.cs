using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlexCommerce
{
    public class Product
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual IList<Category> Categories { get; set; }
    }
}
