using AutoMapper;
using ML.WorkShop.DAL.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ML.WorkShop.BLL.UnitTest
{
    [Binding]
    public class TestHook
    {
        [AfterTestRun]
        public static void AfterTestRun()
        {
            using (var dbContext = MemberDbContext.CreateContext())
            {
                if (dbContext.Database.Exists())
                {
                    dbContext.Database.Delete();
                }
            }
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var instance = SqlProviderServices.Instance;
            Mapper.Initialize(p => p.AddProfile(new DefaultMappingProfile()));
            using (var dbContext = MemberDbContext.CreateContext())
            {
                if (dbContext.Database.Exists())
                {
                    dbContext.Database.Delete();
                }

                dbContext.Database.Initialize(true);


                var CompanyConfing = dbContext.CompanyConfing.Where(p => p.CompanyId == "DDMC").ToList();

                if (CompanyConfing.Count == 0)
                {
                    var CompanyData = new CompanyConfing();

                    CompanyData.CompanyId = "DDMC";
                    CompanyData.Name = "鼎鼎企業管理股份有限公司";

                    dbContext.CompanyConfing.Add(CompanyData);
                    dbContext.SaveChanges();

                }
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            this.DeleteTestDate();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            this.DeleteTestDate();
        }

        private void DeleteTestDate()
        {
            var columnName = "Remark";

            IEnumerable<string> tableNames = new List<string>
            {
                "Role",
                "Identity",
                "MemberActivity",
                "MemberLog",
                "Member",
                
            };

            var deleteCommand = TestUtility.GetDeleteTable(TestUtility.TestData, columnName, tableNames.ToArray());
            using (var dbContext = MemberDbContext.CreateContext())
            {
                dbContext.Database.ExecuteSqlCommand(deleteCommand);
            }
        }
    }
}
