using AutoMapper;
using ML.WorkShop.DAL.EntityModel;
using ML.WorkShop.Infrastructure;
using ML.WorkShop.Infrastructure.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.WorkShop.DAL
{
    public class MemberRepository : IMemberRepository
    {
        private DateTime? _timeNow;

        internal DateTime? TimeNow
        {
            get
            {
                if (!this._timeNow.HasValue)
                {
                    return DateTime.UtcNow;
                }

                return this._timeNow;
            }

            set { this._timeNow = value; }
        }

        public int Delete(MemberViewModel fromUI, string userId)
        {
            var result = 0;

            var memberToDb = new Member();
            var memberLogToDb = new MemberLog();

            Mapper.Map(fromUI, memberToDb);
            Mapper.Map(fromUI, memberLogToDb);


            memberLogToDb.CreateUserId = null;
            memberLogToDb.CreateDateTime = null;
            memberLogToDb.LastModifyUserId = null;
            memberLogToDb.LastModifyDateTime = null;
            memberLogToDb.DeleteUserId = userId;
            memberLogToDb.DeleteDateTime = this.TimeNow.Value;
            memberLogToDb.Id = Guid.NewGuid();
            memberLogToDb.Member_Id = fromUI.Id;

            using (var dbContext = MemberDbContext.CreateContext())
            {
                dbContext.Member.Attach(memberToDb);

                var memberEntry = dbContext.Entry(memberToDb);
                memberEntry.State = EntityState.Deleted;

                dbContext.MemberLog.Add(memberLogToDb);
                result = dbContext.SaveChanges();

            }

            return result;
          
        }

        public int Insert(MemberViewModel fromUI, string userId)
        {
            var result = 0;

            fromUI.CreateDateTime = this.TimeNow.Value;
            fromUI.CreateUserId = userId;

            var memberTodB = new Member();
            var memberLogToDb = new MemberLog();
            var identityToDb = new Identity();
            var roleToDb = new Role();

            Mapper.Map(fromUI, memberTodB);
            Mapper.Map(fromUI, memberLogToDb);
            Mapper.Map(fromUI, identityToDb);
            roleToDb = MapperRole(fromUI);

            memberLogToDb.Member_Id = memberTodB.Id;
            
            identityToDb.Member_Id = memberTodB.Id;
            

            using (var dbContext = MemberDbContext.CreateContext())
            {
                dbContext.Member.Add(memberTodB);
                dbContext.MemberLog.Add(memberLogToDb);
                dbContext.Role.Add(roleToDb);
                dbContext.Identity.Add(identityToDb);
                

                result = dbContext.SaveChanges();
            }

            return result;
        }

        public int Update(MemberViewModel fromUI, string userId)
        {
            var result = 0;
            fromUI.LastModifyDateTime = this.TimeNow.Value;
            fromUI.LastModifyUserId = userId;

            var memberToDb = new Member();
            var memberLogToDb = new MemberLog();
            var identityToDb = new Identity();
            var roleToDb = new Role();

            Mapper.Map(fromUI, memberToDb);
            Mapper.Map(fromUI, identityToDb);
            Mapper.Map(fromUI, memberLogToDb);

            roleToDb = MapperRole(fromUI);
            roleToDb.LastModifyDateTime = this.TimeNow.Value;
            roleToDb.LastModifyUserId = userId;
            
            memberLogToDb.Member_Id = memberToDb.Id;
            identityToDb.Member_Id = memberToDb.Id;
            memberLogToDb.Id = Guid.NewGuid();

            memberLogToDb.CreateUserId = null;
            memberLogToDb.CreateDateTime = null;

            using (var dbContext = MemberDbContext.CreateContext())
            {
               /* dbContext.Member.Attach(memberToDb);
                dbContext.Identity.Attach(identityToDb);
                dbContext.Role.Attach(roleToDb);*/

                var memberEntry = dbContext.Entry(memberToDb);
                memberEntry.State = EntityState.Modified;
                memberEntry.Property(p => p.CreateUserId).IsModified = false;
                memberEntry.Property(p => p.CreateDateTime).IsModified = false;

                var identityEntry = dbContext.Entry(identityToDb);
                identityEntry.State = EntityState.Modified;
                identityEntry.Property(p => p.CreateUserId).IsModified = false;
                identityEntry.Property(p => p.CreateDateTime).IsModified = false;

                var roleEntry = dbContext.Entry(roleToDb);
                roleEntry.State = EntityState.Modified;
                roleEntry.Property(p => p.CreateUserId).IsModified = false;
                roleEntry.Property(p => p.CreateDateTime).IsModified = false;


                dbContext.MemberLog.Add(memberLogToDb);
                result = dbContext.SaveChanges();

            }

            return result;   

        }

        public IEnumerable<MemberListViewModel> GetMembers(MemberFilterModel filter, GridState gridState)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            IEnumerable<MemberListViewModel> results = null;

            using (var dbcontext = MemberDbContext.CreateContext())
            {
                var queryable = this.ApplyJoin(dbcontext.Member, dbcontext.Identity, dbcontext.Role,
                                                dbcontext.CompanyConfing, dbcontext.MemberActivity);

                queryable = this.ApplyFilter(filter, queryable);

                queryable = this.ApplyPaging(gridState, queryable);

                results = queryable.AsNoTracking().ToList();
            }

            return results;
        }

        public MemberDetailViewModel GetMemberDetail(Guid? MemberId)
        {
            MemberDetailViewModel results = null;

            using (var dbcontext = MemberDbContext.CreateContext())
            {
                var queryable = this.ApplyJoinDetail(dbcontext.Member, dbcontext.Identity, dbcontext.Role,
                                                dbcontext.CompanyConfing, dbcontext.MemberActivity);

                queryable = queryable.Where(x => x.Id == MemberId);

                results = queryable.First();
            }

            return results;
        }

        private Role MapperRole(MemberViewModel Data)
        {
            var result = new Role();

            result.Id = Data.Id;

            if (Data.RoleName == "Administrator")
            {
                result.Administrator = true;
            }
            else if (Data.RoleName == "Member")
            {
                result.Member = true;
            }
            else if (Data.RoleName == "Lock")
            {
                result.Lock = true;
            }

            result.CreateDateTime = Data.CreateDateTime;
            result.CreateUserId = Data.CreateUserId;
            result.Remark = Data.Remark;

            return result;
         
        }

        private IQueryable<MemberListViewModel> ApplyJoin(IQueryable<Member> members,
                                                      IQueryable<Identity> identities,
                                                      IQueryable<Role> roles,
                                                      IQueryable<CompanyConfing> comapnys,
                                                      IQueryable<MemberActivity> activitys)
        {
            var joinable = from employee in members

                           join identity in identities
                               on employee.Id equals identity.Member_Id
                               into identityTemps
                           from identity in identityTemps.DefaultIfEmpty()

                           join role in roles
                               on employee.Id equals role.Id
                               into roleTemps
                           from role in roleTemps.DefaultIfEmpty()

                           join company in comapnys
                               on employee.CompanyId equals company.Id
                               into companyTemps
                           from company in companyTemps.DefaultIfEmpty()

                           join activity in activitys
                              on employee.Id equals activity.Member_Id
                              into activitysTemps
                           from activity in activitysTemps.DefaultIfEmpty()

                           select new MemberListViewModel
                           {
                               Id = employee.Id,
                               WorkId = employee.WorkId,
                               CompanyName = company.Name,
                               CompanyId = company.CompanyId,
                               Name = employee.Name,
                               Email = employee.Email,
                               Admin = role.Administrator == null ? default(bool) : role.Administrator,
                               Member = role.Member == null ? default(bool) : role.Member,
                               Lock = role.Lock == null ? default(bool) : role.Lock,
                               LastLoginDateTime =  activity == null ? null : activity.LoginDateTime,
                               LastModifyPasswordDate = activity == null ? null : activity.LastModifyPasswordDate,
                               Remark = employee.Remark,

                           };
            return joinable;
        }

        private IQueryable<MemberDetailViewModel> ApplyJoinDetail(IQueryable<Member> members,
                                                      IQueryable<Identity> identities,
                                                      IQueryable<Role> roles,
                                                      IQueryable<CompanyConfing> comapnys,
                                                      IQueryable<MemberActivity> activitys)
        {
            var joinable = from employee in members

                           join identity in identities
                               on employee.Id equals identity.Member_Id
                               into identityTemps
                           from identity in identityTemps.DefaultIfEmpty()

                           join role in roles
                               on employee.Id equals role.Id
                               into roleTemps
                           from role in roleTemps.DefaultIfEmpty()

                           join company in comapnys
                               on employee.CompanyId equals company.Id
                               into companyTemps
                           from company in companyTemps.DefaultIfEmpty()

                           join activity in activitys
                              on employee.Id equals activity.Member_Id
                              into activitysTemps
                           from activity in activitysTemps.DefaultIfEmpty()

                           select new MemberDetailViewModel
                           {
                               Id = employee.Id,
                               WorkId = employee.WorkId,
                               CompanyName = company.Name,
                               CompanyId = company.CompanyId,
                               Password = identity.Password,
                               Age = employee.Age,
                               Name = employee.Name,
                               Email = employee.Email,
                               Admin = role.Administrator == null ? default(bool) : role.Administrator,
                               Member = role.Member == null ? default(bool) : role.Member,
                               Lock = role.Lock == null ? default(bool) : role.Lock,
                               CreateDateTime = employee.CreateDateTime,
                               CreateUserId = employee.CreateUserId,
                               LastModifyDateTime = (!employee.LastModifyDateTime.HasValue) ? null : employee.LastModifyDateTime,
                               LastModifyUserId = employee.LastModifyUserId,
                               LastLoginDateTime = activity == null ? null : activity.LoginDateTime,
                               LastModifyPasswordDate = activity == null ? null : activity.LastModifyPasswordDate,
                               Remark = employee.Remark,

                           };
            return joinable;
        }


        private IQueryable<MemberListViewModel> ApplyFilter(MemberFilterModel filter, IQueryable<MemberListViewModel> queryable)
        {
            if (filter.WorkId.HasValue)
            {
                queryable = queryable.Where(p => p.WorkId == filter.WorkId);
            }

            if (!string.IsNullOrWhiteSpace(filter.CompanyName))
            {
                queryable = queryable.Where(p => p.CompanyName.Contains(filter.CompanyName));
            }

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                queryable = queryable.Where(p => p.Name == filter.Name);
            }

            if (!string.IsNullOrWhiteSpace(filter.Email))
            {
                queryable = queryable.Where(p => p.Email == filter.Email);
            }

            if (filter.Admin.HasValue)
            {
                queryable = queryable.Where(p => p.Admin == filter.Admin);
            }

            if (filter.Member.HasValue)
            {
                queryable = queryable.Where(p => p.Member == filter.Member);
            }

            if (filter.Lock.HasValue)
            {
                queryable = queryable.Where(p => p.Lock == filter.Lock);
            }

            return queryable;
        }

        private IQueryable<MemberListViewModel> ApplyPaging(GridState gridState, IQueryable<MemberListViewModel> queryable)
        {
            queryable = queryable.OrderBy(p => p.WorkId).Skip(gridState.Skip).Take(gridState.PageSize);
            return queryable;
        }

        
    }
}
