using ML.WorkShop.Infrastructure;
using ML.WorkShop.Infrastructure.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.WorkShop.DAL
{
    public interface IMemberRepository
    {
        int Insert(MemberViewModel fromUI, string userId);

        int Update(MemberViewModel fromUI, string userId);

        int Delete(MemberViewModel fromUI, string userId);

        IEnumerable<MemberListViewModel> GetMembers(MemberFilterModel filter, GridState gridState);

        MemberDetailViewModel GetMemberDetail(Guid? filterId);
    }
}
