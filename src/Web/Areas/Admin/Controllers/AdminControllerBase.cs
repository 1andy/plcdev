using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;

namespace PlexCommerce.Web.Areas.Admin.Controllers
{
    public abstract class AdminControllerBase : PlexControllerBase
    {
        private readonly ISession _session;

        protected AdminControllerBase(ISession session)
        {
            _session = session;
        }

        protected override void SetAdditionalViewModelData(object model)
        {
            var sharedLayoutViewModel = model as SharedLayoutViewModel;
            if (sharedLayoutViewModel != null)
            {
                sharedLayoutViewModel.UserName = "1andy";
                sharedLayoutViewModel.StoreName = "Jama Stuff";
            }

            base.SetAdditionalViewModelData(model);
        }
    }
}
