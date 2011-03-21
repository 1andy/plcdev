﻿using System;
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

        public CategoriesController(ISession session)
        {
            _session = session;
        }

        public ActionResult Index()
        {
            var model = new CategoriesIndexViewModel();
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new CategoriesAddViewModel();
            SetupCategoriesAddViewModel(model);

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

            SetupCategoriesAddViewModel(model);
            return View(model);
        }

        private void SetupCategoriesAddViewModel(CategoriesAddViewModel model)
        {
            model.ParentCategoryIDSelectList = new List<SelectListItem> { new SelectListItem() };

            model.ParentCategoryIDSelectList.AddRange(
                from c in _session.Query<Category>()
                select new SelectListItem
                       {
                           Value = c.Id.ToString(),
                           Text = c.Name
                       });
        }
    }
}