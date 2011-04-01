/*
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace PlexCommerce
//{
//    public class ProductCollectionTypeAttribute : Attribute
//    {
//        public string Name { get; set; } // Categories
//        public string SingleName { get; set; } // Category

//        public string AddText { get; set; } // select vendor, show on front page, add to another category, add to collection

//        public bool AllowMultiple { get; set; }
//        public bool AllowProductInMultipleCollectionsOfThisType { get; set; }
//    }


//    public abstract class ProductCollection
//    {
//        public string Name { get; set; }
//        public IList<Product> Products { get; set; }

//        // attributes
//    }

//    public abstract class TemplatedProductCollection : ProductCollection
//    {
//        public string DescriptionHtml { get; set; }
//        public object Picture { get; set; }
//    }

//    [ProductCollectionTypeAttribute(Name = "Categories", AllowMultiple = true, AllowProductInMultipleCollectionsOfThisType = true)]
//    public class Category2 : TemplatedProductCollection
//    {
//        public Category2 ParentCategory { get; set; }

//        public IList<Category2> ChildCategories { get; set; }
//    }

//    [ProductCollectionTypeAttribute(Name = "Vendors", AllowMultiple = true)]
//    public class Vendor : TemplatedProductCollection
//    {

//    }

//    [ProductCollectionTypeAttribute(Name = "FrontPage")]
//    public class FrontPageProducts : ProductCollection
//    {

//    }

//    public class SmartProductCollection : TemplatedProductCollection
//    {

//    }

//    public static class ProductCollectionsManager
//    {
//        public static T GetCollection<T>() where T : ProductCollection
//        {
//            //lalala
//        }

//        public static IEnumerable<T> GetCollections<T>() where T : ProductCollection
//        {
//            //lalala
//        }
//    }

//    public static class Pages
//    {
//        public static void MainPage()
//        {
//            var allcategories = ProductCollectionsManager.GetCollections<Category2>();
//            // iterate over such

//            var fromPageProducts = ProductCollectionsManager.GetCollection<FrontPageProducts>().Products;
//        }

//    }
//}
*/