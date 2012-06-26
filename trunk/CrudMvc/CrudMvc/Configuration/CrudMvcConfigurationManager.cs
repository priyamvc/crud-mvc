using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace CrudMvc.Configuration
{
    public static class CrudMvcConfigurationManager
    {
        private static readonly CrudMvcSection Section =
            (CrudMvcSection)ConfigurationManager.GetSection("crudMvc");

        public static Assembly EntityAssembly
        {
            get { return Assembly.Load(Section.EntityAssemblyName); }
        }

        public static Type DbContextType
        {
            get { return Type.GetType(Section.DbContextTypeName); }
        }

        public static IEnumerable<string> ExcludedEntities
        {
            get { return Section.ExcludedEntities.Split(','); }
        } 
    }
}
