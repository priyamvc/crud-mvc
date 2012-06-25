using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using CrudMvc.Controller;

namespace CrudMvc.Configuration {
    public class CrudMvcControllerFactory : DefaultControllerFactory {
        private readonly Assembly _entityAssembly;
        public CrudMvcControllerFactory()
        {
            _entityAssembly = CrudMvcConfigurationManager.EntityAssembly;
        }

        protected override Type GetControllerType(RequestContext requestContext, string controllerName) {
            Type controllerType = base.GetControllerType(requestContext, controllerName);

            try {
                if(controllerType == null) {
                    if(controllerName.EndsWith("Crud")) {
                        string entityName = controllerName.Substring(0, controllerName.Length - 4);
                        Type entityType = _entityAssembly.GetTypes().First(type => type.Name == entityName);
                        controllerType = typeof(CrudController<>).MakeGenericType(entityType);
                    }
                }
            } catch { }


            return controllerType;
        }
    }
}
