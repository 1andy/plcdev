using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.WebPages;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;

namespace PlexCommerce.Web.Areas.Admin.Controllers
{
    public class CategoriesController : AdminControllerBase
    {
        private readonly ISession _session;

        #region ctor

        public CategoriesController(ISession session) : base(session)
        {
            _session = session;
        }

        #endregion

        public ActionResult Index()
        {
            var model = new CategoriesIndexViewModel();

            model.Categories = _session.Query<Category>().Where(c => c.ParentCategory == null).ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new CategoriesAddViewModel();

            SetupAddViewModel(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Add([Bind(Prefix = "AddForm")] CategoriesAddForm form)
        {
            var model = new CategoriesAddViewModel();

            if (ModelState.IsValid)
            {
                var category = new Category
                               {
                                   Name = form.Name,
                                   Description = form.Description ?? string.Empty,
                                   ParentCategory = form.ParentCategoryID == null ? null : _session.Load<Category>(form.ParentCategoryID)
                               };

                _session.Save(category);
                TempData["SuccessMessage"] = "Category has been created";
                return RedirectToAction("Index");
            }

            SetupAddViewModel(model);
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = _session.Get<Category>(id);
            return Content("test");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var category = _session.Get<Category>(id);
            _session.Delete(category);
            _session.Flush();

            TempData["SuccessMessage"] = "The category has been deleted";
            return RedirectToAction("Index");
        }

        private void SetupAddViewModel(CategoriesAddViewModel model)
        {
            model.ParentCategoryIDListItems = new List<SelectListItem> { new SelectListItem() };

            model.ParentCategoryIDListItems.AddRange(
                from c in _session.Query<Category>()
                select new SelectListItem
                       {
                           Value = c.Id.ToString(),
                           Text = c.Name
                       });
        }
    }
}