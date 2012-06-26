using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using CrudMvc.Controller;

namespace CrudMvc.Configuration
{
    public class CrudMvcControllerFactory : DefaultControllerFactory
    {
        private readonly Assembly _entityAssembly;
        public CrudMvcControllerFactory()
        {
            _entityAssembly = CrudMvcConfigurationManager.EntityAssembly;
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            IController controller;
            try
            {
                controller = base.CreateController(requestContext, controllerName);
            }
            catch (Exception)
            {
                if (controllerName.EndsWith("Crud"))
                {
                    string entityName = controllerName.Substring(0, controllerName.Length - 4);
                    Type entityType = _entityAssembly.GetTypes().First(type => type.Name == entityName);
                    if (CrudMvcConfigurationManager.ExcludedEntities.Contains(entityName))
                    {
                        throw new UnauthorizedAccessException("Crud actions are not allowed for entity: " + entityType.AssemblyQualifiedName);
                    }

                    Type controllerType = typeof(CrudController<>).MakeGenericType(entityType);
                    controller = (IController)CrudMvcDependencyResolver.Resolver.GetService(controllerType);
                }
                else
                {
                    throw;
                }
            }

            return controller;
        }
    }
}
