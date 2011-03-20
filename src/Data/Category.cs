using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlexCommerce
{
    public class Category
    {
        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
