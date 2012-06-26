using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using CrudMvc.Controller;
using Ninject;

namespace CrudMvc.Configuration
{
    public class CrudMvcDependencyResolver : IDependencyResolver
    {
        private static readonly IDependencyResolver ResolverInstance = new CrudMvcDependencyResolver();
        public static IDependencyResolver Resolver { get { return ResolverInstance; } }

        private readonly IKernel _kernel = new StandardKernel();
        private CrudMvcDependencyResolver()
        {
            _kernel.Bind(typeof(CrudController<>)).ToSelf();
            _kernel.Bind<DbContext>().To(CrudMvcConfigurationManager.DbContextType);
        }
        object IDependencyResolver.GetService(Type serviceType)
        {
            return _kernel.Get(serviceType);
        }

        IEnumerable<object> IDependencyResolver.GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}
