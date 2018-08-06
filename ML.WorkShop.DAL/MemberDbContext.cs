using System.Configuration;
using System.Data.Entity;

namespace ML.WorkShop.DAL.EntityModel
{
    public partial class MemberDbContext
    {
        public static MemberDbContext CreateContext(string connectionStringName = "MemberDbContext")
        {
            var setting = ConfigurationManager.ConnectionStrings[connectionStringName];

            if (setting == null)
            {
                return null;
            }

            var result = new MemberDbContext();
            string connectString = null;

            connectString = setting.ConnectionString;

            result.Database.Connection.ConnectionString = connectString;
            result.Configuration.AutoDetectChangesEnabled = false;
            result.Configuration.LazyLoadingEnabled = false;
            result.Configuration.ProxyCreationEnabled = false;

            return result;
        }

    }
}
