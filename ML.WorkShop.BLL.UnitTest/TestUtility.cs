using ML.WorkShop.DAL.EntityModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.WorkShop.BLL.UnitTest
{
    public class TestUtility
    {
        public static readonly string TestData = "出發吧，跟我一起進入偉大的航道";
        public static readonly DateTime TestDateTime = new DateTime(1900, 1, 1, 0, 0, 0);
        public static readonly string TestUserId = "TEST_USER";
        public static  Guid TestComapnyData()
        {

            using (var dbContext = MemberDbContext.CreateContext())
            {
                var compnayConfig = dbContext.CompanyConfing.Where(p => p.CompanyId == "DDMC").FirstOrDefault().Id;

                return compnayConfig;
            }
        }
        

        public static string GetDeleteTable(string testData,
                                            string columnName = "Remark",
                                            params string[] tableNames)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(testData), "!string.IsNullOrWhiteSpace(testData)");
            Contract.Requires(!string.IsNullOrWhiteSpace(columnName), "!string.IsNullOrWhiteSpace(columnName)");
            Contract.Requires(tableNames != null, "tableNames!=null");

            var commandBuilder = new StringBuilder();
            foreach (var tableName in tableNames)
            {
                if (string.IsNullOrWhiteSpace(tableName))
                {
                    continue;
                }

                var deleteCommand = $@"
delete from [{tableName}]
    where {columnName} = N'{testData}'
";

                commandBuilder.AppendLine(deleteCommand);
            }

            return commandBuilder.ToString();
        }

        /*public static Guid Parse(string id)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(id), "!string.IsNullOrWhiteSpace(id)");
            var _guidFormat = "{0}-0000-0000-0000-000000000000";
            var guidText = string.Format(_guidFormat, id.PadRight(8, '0'));
            var key = Guid.Parse(guidText);
            return key;
        }*/
    }
}
