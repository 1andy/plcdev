using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlexCommerce
{
    public class PaymentMethod
    {
        public virtual int Id { get; private set; }

        public virtual string Name { get; set; }

        public virtual string ModuleType { get; set; }

        public virtual string ModuleSettings { get; set; }
    }
}
