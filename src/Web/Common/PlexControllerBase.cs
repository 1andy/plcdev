using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlexCommerce.Web
{
    public abstract class PlexControllerBase : Controller
    {
        protected virtual void SetAdditionalViewModelData(object model)
        {
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResultBase;
            if (viewResult != null && viewResult.ViewData.Model != null)
            {
                SetAdditionalViewModelData(viewResult.ViewData.Model);
            }
            base.OnResultExecuting(filterContext);
        }
    }
}