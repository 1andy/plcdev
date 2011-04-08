using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;

namespace PlexCommerce.Web.Controllers
{
    public class ProductsController : StoreControllerBase
    {
        private readonly ISession _session;

        #region ctor

        public ProductsController(ISession session)
            : base(session)
        {
            _session = session;
        }

        #endregion

        public ActionResult View(int id)
        {
            var model = new ProductsViewViewModel { Product = _session.Get<Product>(id) };

            return View(model);
        }
    }
}
