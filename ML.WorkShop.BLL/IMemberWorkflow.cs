using ML.WorkShop.DAL;
using ML.WorkShop.Infrastructure;
using ML.WorkShop.Infrastructure.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.WorkShop.BLL
{
    public interface IMemberWorkflow
    {
        IMemberRepository MemberRepository { get; set; }

        MemberViewModel Insert(MemberViewModel fromUI, string userId);

        MemberViewModel Update(MemberViewModel fromUI, string userId);

        void Delete(MemberViewModel fromUI, string testUserId);

        IEnumerable<MemberListViewModel> GetMembers(MemberFilterModel filter, GridState gridState);

        MemberDetailViewModel GetMemberDetail(Guid? MemberId);
    }
}
