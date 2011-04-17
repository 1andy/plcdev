////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;

////namespace PlexCommerce
////{
////    public interface IShippingRate
////    {
////        string Name { get; }

////        decimal ShippingPrice { get; set; }
////    }

////    public interface IShippingOptionsProvider
////    {
////        IShippingRate[] GetShippingOptions(Order order);
////    }

////    public class RegionShippingOptionsProvider //: IShippingOptionsProvider
////    {
////        public IShippingRate[] GetShippingOptions(Order order)
////        {
////            // get order weight, price and region and see  the options
////            return null;
////        }
////    }

////    public class UspsShippingOptionsProvider : IShippingOptionsProvider
////    {
////        public IShippingRate[] GetShippingOptions(Order order)
////        {
////            return null;
////        }
////    }

////}
