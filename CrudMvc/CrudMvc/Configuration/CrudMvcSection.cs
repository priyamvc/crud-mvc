using System.Configuration;

namespace CrudMvc.Configuration
{
    public class CrudMvcSection : ConfigurationSection
    {
        [ConfigurationProperty("dbContextType")]
        public string DbContextTypeName
        {
            get { return (string)this["dbContextType"]; }
            set { this["dbContextType"] = value; }
        }

        [ConfigurationProperty("entityAssembly", IsRequired = false)]
        public string EntityAssemblyName
        {
            get { return (string)this["entityAssembly"]; }
            set { this["entityAssembly"] = value; }
        }

        [ConfigurationProperty("excludedEntities")]
        public string ExcludedEntities
        {
            get { return (string)this["excludedEntities"]; }
            set { this["excludedEntities"] = value; }
        }
    }
}
