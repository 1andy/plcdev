﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlexCommerce.PaymentMethods
{
    public class BogusGateway : IPaymentModule
    {
        public string Name
        {
            get { return "Bogus Gateway"; }
        }
    }
}
