using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace PlexCommerce.Web.Areas.Admin.Controllers
{
    [ValidateInput(false)]
    public class ProductsController : AdminControllerBase
    {
        private readonly ISession _session;

        public ProductsController(ISession session)
        {
            _session = session;
        }

        public ActionResult Index(string q)
        {
            var model = new ProductsIndexViewModel();

            return View(model);
        }

        #region Add

        [HttpGet]
        public ActionResult Add()
        {
            var model = new ProductsAddViewModel { AddForm = new ProductsAddForm() };

            SetupAddViewModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Add([Bind(Prefix = "AddForm")] ProductsAddForm form)
        {
            var model = new ProductsAddViewModel { AddForm = form };

            if (ModelState.IsValid)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    var product = new Product
                                  {
                                      Name = form.Name,
                                      Description = form.Description ?? string.Empty
                                  };

                    var primaryVariant = new ProductVariant
                                         {
                                             Price = form.Price.Value,
                                             Sku = form.Sku ?? string.Empty,
                                             Product = product
                                         };

                    product.Variants = new[] { primaryVariant };

                    _session.Save(product);
                    transaction.Commit();
                    return RedirectToAction("View", new { id = product.Id });
                }
            }

            SetupAddViewModel(model);
            return View(model);
        }

        private static void SetupAddViewModel(ProductsAddViewModel model)
        {
            var defaultItems = new[] { "Title", "Color", "Size" };

            model.DefaultOptionNameListItems = (from it in defaultItems
                                                select new SelectListItem
                                                       {
                                                           Value = it,
                                                           Text = it
                                                       }).ToList();

            if (model.AddForm.Options == null)
            {
                model.AddForm.Options = new List<ProductOptionData>();
            }

            var options = model.AddForm.Options;

            // make sure we have 3 options
            if (options.Count < 1)
            {
                options.Add(new ProductOptionData { Disabled = true });
            }

            if (options.Count < 2)
            {
                options.Add(new ProductOptionData { Disabled = true });
            }

            if (options.Count < 3)
            {
                options.Add(new ProductOptionData { Disabled = true });
            }
        }

        #endregion

        #region View

        public ActionResult View(int id)
        {
            var product = _session.Get<Product>(id);

            var model = new ProductsViewViewModel
                        {
                            Name = product.Name
                        };

            //var cats = _session.CreateCriteria(typeof(Category))
            //    .Add(Restrictions.IsNull("ParentCategory"))
            //    .SetFetchMode("ChildCategories", FetchMode.Eager)
            //    .SetFetchMode("ChildCategories.ChildCategories", FetchMode.Eager)
            //    .SetFetchMode("ChildCategories.ChildCategories.ChildCategories", FetchMode.Eager)
            //    .List<Category>();

            //ExploreCats(cats);

            var rootCategories = _session.Query<Category>().Where(c => c.ParentCategory == null)
                .FetchMany(c => c.ChildCategories).ThenFetchMany(c => c.ChildCategories).ThenFetchMany(c => c.ChildCategories);

            model.CategoriesListItems = CreateListItemsFromCategories(rootCategories);

            //ExploreCats(cats2);

            //var categories = _session.QueryOver<Category>().Where(c => c.ParentCategory == null);

            //categories.ToList();)

            return View(model);
        }

        private static IEnumerable<SelectListItem> CreateListItemsFromCategories(IEnumerable<Category> categories, int level = 0)
        {
            string prefix = string.Empty.PadRight(level * 4,'.');
            var items = new List<SelectListItem>();

            foreach (var category in categories)
            {
                var item = new SelectListItem
                           {
                               Value = category.Id.ToString(),
                               Text = prefix + category.Name
                           };
                items.Add(item);
                items.AddRange(CreateListItemsFromCategories(category.ChildCategories, level + 1));
            }

            return items;
        }

        //private void ExploreCats(IEnumerable<Category> cats)
        //{
        //    foreach (var c in cats)
        //    {
        //        ExploreCats(c.ChildCategories);
        //    }
        //}

        #endregion

        public ActionResult Search()
        {
            var model = new ProductsSearchViewModel();

            return View(model);
        }
    }
}
