using ML.WorkShop.DAL;
using ML.WorkShop.DAL.EntityModel;
using ML.WorkShop.Infrastructure;
using ML.WorkShop.Infrastructure.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ML.WorkShop.BLL.UnitTest
{
    [Binding]
    public class 員工資料管理Steps
    {
        [Given(@"前端應傳來以下MemberViewModel資料")]
        public void Given前端應傳來以下MemberViewModel資料(Table table)
        {
            var fromUI = table.CreateInstance(() => new MemberViewModel
            {
                Remark = TestUtility.TestData,
                CreateDateTime = TestUtility.TestDateTime,
                CreateUserId = TestUtility.TestUserId,
            });

            fromUI.CompanyId = TestUtility.TestComapnyData().ToString();

            ScenarioContext.Current.Set(fromUI, "fromUI");
        }
        
        [When(@"調用MemberWorkflow\.Insert")]
        public void When調用MemberWorkflow_Insert()
        {
            var fromUI = ScenarioContext.Current.Get<MemberViewModel>("fromUI");
            var target = this.CreateMemberWorkflow();
            target.Insert(fromUI, TestUtility.TestUserId);
        }
        
        [Then(@"預期資料庫的Member資料表應有以下資料")]
        public void Then預期資料庫的Member資料表應有以下資料(Table expected)
        {
            using (var dbContext = MemberDbContext.CreateContext())
            {
                var actual = dbContext.Member
                                      .Where(p => p.Remark == TestUtility.TestData)
                                      .AsNoTracking()
                                      .ToList();

                expected.CompareToSet(actual);
            }
        }
        
        [Then(@"預期資料庫的Identity資料表應有以下資料")]
        public void Then預期資料庫的Identity資料表應有以下資料(Table expected)
        {
            using (var dbContext = MemberDbContext.CreateContext())
            {
                var actual = dbContext.Identity
                                      .Where(p => p.Remark == TestUtility.TestData)
                                      .AsNoTracking()
                                      .ToList();

                expected.CompareToSet(actual);
            }
        }
        
        [Then(@"預期資料庫的MemberLog資料表應有以下資料")]
        public void Then預期資料庫的MemberLog資料表應有以下資料(Table expected)
        {
            using (var dbContext = MemberDbContext.CreateContext())
            {
                var actual = dbContext.MemberLog
                                      .Where(p => p.Remark == TestUtility.TestData)
                                      .AsNoTracking()
                                      .ToList();

                expected.CompareToSet(actual);
            }
        }
        
        [Then(@"預期資料庫的Role資料表應有以下資料")]
        public void Then預期資料庫的Role資料表應有以下資料(Table expected)
        {
            using (var dbContext = MemberDbContext.CreateContext())
            {
                var actual = dbContext.Role
                                      .Where(p => p.Member == true )
                                      .AsNoTracking()
                                      .ToList();

                expected.CompareToSet(actual);
            }
        }

        [Given(@"資料庫的Member資料表已經存在以下資料")]
        public void Given資料庫的Member資料表已經存在以下資料(Table table)
        {
            var toDb = table.CreateSet(() => new Member
            {
                CreateUserId = TestUtility.TestUserId,
                CreateDateTime = TestUtility.TestDateTime,
                Remark = TestUtility.TestData,
                CompanyId = TestUtility.TestComapnyData()
            });

            using (var dbContext = MemberDbContext.CreateContext()) 
            {
                dbContext.Member.AddRange(toDb);
                dbContext.SaveChanges();
            }        

        }

        [Given(@"資料庫的Identity資料表已經存在以下資料")]
        public void Given資料庫的Identity資料表已經存在以下資料(Table table)
        {
            var toDb = table.CreateSet(() => new Identity
            {
                CreateUserId = TestUtility.TestUserId,
                CreateDateTime = TestUtility.TestDateTime,
                Remark = TestUtility.TestData
            });
            using (var dbContext = MemberDbContext.CreateContext())
            {
                dbContext.Identity.AddRange(toDb);
                dbContext.SaveChanges();
            }
        }

        [Given(@"資料庫的Role資料表已經存在以下資料")]
        public void Given資料庫的Role資料表已經存在以下資料(Table table)
        {
            var toDb = table.CreateSet(() => new Role
            {
                CreateUserId = TestUtility.TestUserId,
                CreateDateTime = TestUtility.TestDateTime,
            });

            using (var dbContext = MemberDbContext.CreateContext())
            {
                dbContext.Role.AddRange(toDb);
                dbContext.SaveChanges();
            }
        }

        [Given(@"資料庫的MemberLog資料表已經存在以下資料")]
        public void Given資料庫的MemberLog資料表已經存在以下資料(Table table)
        {
            var toDb = table.CreateSet(() => new MemberLog
            {
                CreateUserId = TestUtility.TestUserId,
                CreateDateTime = TestUtility.TestDateTime,
                Remark = TestUtility.TestData
            });

            using (var dbContext = MemberDbContext.CreateContext())
            {
                dbContext.MemberLog.AddRange(toDb);
                dbContext.SaveChanges();
            }
        }

        [When(@"調用MemberWorkflow\.Update")]
        public void When調用MemberWorkflow_Update()
        {
            var fromUI = ScenarioContext.Current.Get<MemberViewModel>("fromUI");
            var target = this.CreateMemberWorkflow();
            target.Update(fromUI, TestUtility.TestUserId);
        }

        [When(@"調用MemberWorkflow\.Delete")]
        public void When調用MemberWorkflow_Delete()
        {
            var fromUI = ScenarioContext.Current.Get<MemberViewModel>("fromUI");
            var target = this.CreateMemberWorkflow();
            target.Delete(fromUI, TestUtility.TestUserId);
        }

        [Given(@"資料庫的MemberActivity資料表已經存在以下資料")]
        public void Given資料庫的MemberActivity資料表已經存在以下資料(Table table)
        {
            var toDb = table.CreateSet(() => new MemberActivity
            {
               
            });

            using (var dbContext = MemberDbContext.CreateContext())
            {
                dbContext.MemberActivity.AddRange(toDb);
                dbContext.SaveChanges();
            }
        }

        [Given(@"前端應傳來以下MemberFilterModel資料")]
        public void Given前端應傳來以下MemberFilterModel資料(Table table)
        {
            var filter = table.CreateInstance<MemberFilterModel>();
            ScenarioContext.Current.Set(filter, "filter");
        }

        [Given(@"前端應傳來以下GridState資料")]
        public void Given前端應傳來以下GridState資料(Table table)
        {
            var gridState = table.CreateInstance<GridState>();
            ScenarioContext.Current.Set(gridState, "gridState");
        }

        [When(@"調用MemberWorkflow\.GetMembers")]
        public void When調用MemberWorkflow_GetMembers()
        {
            var filter = ScenarioContext.Current.Get<MemberFilterModel>("filter");
            var gridState = ScenarioContext.Current.Get<GridState>("gridState");
            var target = this.CreateMemberWorkflow();
            var actual = target.GetMembers(filter, gridState);
            ScenarioContext.Current.Set(actual, "actual");
        }

        [Then(@"預期查詢得到以下MemberListViewModel資料")]
        public void Then預期查詢得到以下MemberViewModel資料(Table expected)
        {
            var actual = ScenarioContext.Current.Get<IEnumerable<MemberListViewModel>>("actual");
            expected.CompareToSet(actual);
        }

        [When(@"調用MemberWorkflow\.GetMemberDetail")]
        public void When調用MemberWorkflow_GetMemberDetail()
        {
            var filter = ScenarioContext.Current.Get<MemberFilterModel>("filter");

            var target = this.CreateMemberWorkflow();
            var actual = target.GetMemberDetail(filter.Id);
            ScenarioContext.Current.Set(actual, "actual");
        }

        [Then(@"預期查詢得到以下MemberDetailViewModel資料")]
        public void Then預期查詢得到以下MemberDetailViewModel資料(Table expected)
        {
            var actual = ScenarioContext.Current.Get<MemberDetailViewModel>("actual");
            expected.CompareToInstance(actual);
        }



        private IMemberWorkflow CreateMemberWorkflow()
        {
            IMemberWorkflow target = new MemberWorkflow();
            ((MemberRepository)target.MemberRepository).TimeNow = TestUtility.TestDateTime;
            return target;
        }
    }
}
