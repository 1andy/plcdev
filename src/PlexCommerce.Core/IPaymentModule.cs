using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlexCommerce
{
    public interface IPaymentModule
    {
        string Name { get; }
    }
}
