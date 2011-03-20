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
            return View(model);
        }

        [HttpPost]
        public ActionResult Add([Bind(Include = "AddForm")] CategoriesAddViewModel model)
        {
            var form = model.AddForm;

            if (ModelState.IsValid)
            {
                var category = new Category { Name = form.Name, Description = form.Description };
                _session.Save(category);
                TempData["SuccessMessage"] = "Category has been created";
            }

            model.AddForm.Name += "1";
            ModelState.Clear();

            return View(model);
        }

        ////                private static void BuildSchema(Configuration config)
        //                {
        //                    //// delete the existing db on each run
        //        if (File.Exists(DbFile))
        //            File.Delete(DbFile);
        //        
        //         this NHibernate tool takes a configuration (with mapping info in)
        //         and exports a database schema from it
        //                    var schema = new SchemaExport(config);
        //        
        //                    schema.SetOutputFile(@"d:\schema.txt").Create(true, true);
        //        
        //        schema.Create(false, true);
        //                }
    }
}
