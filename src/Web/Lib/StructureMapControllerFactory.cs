using System;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace PlexCommerce.Web
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controllerType = GetControllerType(requestContext, controllerName);
            if (controllerType == null)
            {
                return base.CreateController(requestContext, controllerName);
            }

            return ObjectFactory.GetInstance(controllerType) as IController;
        }
    }
}