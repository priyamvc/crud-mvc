using System;
using System.Configuration;
using System.Reflection;

namespace CrudMvc.Configuration
{
    public static class CrudMvcConfigurationManager
    {
        private static readonly CrudMvcSection Section =
            (CrudMvcSection)ConfigurationManager.GetSection("crudMvcGroup/crudMvc");

        public static Assembly EntityAssembly
        {
            get { return Assembly.Load(Section.EntityAssemblyName); }
        }

        public static Type DbContextType
        {
            get { return Type.GetType(Section.DbContextTypeName); }
        }
    }
}
