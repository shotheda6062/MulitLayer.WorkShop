using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML.WorkShop.DAL;
using ML.WorkShop.Infrastructure;
using ML.WorkShop.Infrastructure.ViewModel;

namespace ML.WorkShop.BLL
{
    public class MemberWorkflow : IMemberWorkflow
    {
        private IMemberRepository _memberRepository;

        public IMemberRepository MemberRepository
        {
            get
            {
                if (this._memberRepository == null)
                {
                    this._memberRepository = new MemberRepository();
                }

                return this._memberRepository;
            }
            set { this._memberRepository = value; }
        }

        public void Delete(MemberViewModel fromUI, string userId)
        {
            if (fromUI == null)
            {
                throw new ArgumentNullException(nameof(fromUI));
            }

            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var count = this.MemberRepository.Delete(fromUI, userId);
            if (count != 2)
            {
                throw new Exception("刪除資料失敗");
            }
        }

        public MemberDetailViewModel GetMemberDetail(Guid? MemberId)
        {
            MemberDetailViewModel result = null;

            result = this.MemberRepository.GetMemberDetail(MemberId);

            return result;
        }

        public IEnumerable<MemberListViewModel> GetMembers(MemberFilterModel filter, GridState gridState)
        {
            IEnumerable<MemberListViewModel> result = null;
            result = this.MemberRepository.GetMembers(filter, gridState);
            return result;
        }

        public MemberViewModel Insert(MemberViewModel fromUI, string userId)
        {
            if (fromUI == null)
            {
                throw new ArgumentNullException(nameof(fromUI));
            }

            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentNullException(nameof(userId));
            }

            MemberViewModel result = null;
            var count = this.MemberRepository.Insert(fromUI, userId);
            if (count != 4)
            {
                throw new Exception("新增資料失敗");
            }

            result = fromUI;
            return result;
        }

        public MemberViewModel Update(MemberViewModel fromUI, string userId)
        {
            if (fromUI == null)
            {
                throw new ArgumentNullException(nameof(fromUI));
            }

            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentNullException(nameof(userId));
            }
                        
            MemberViewModel result = null;
            var count = this.MemberRepository.Update(fromUI, userId);

            if (count != 4)
            {
                throw new Exception("編輯資料失敗");
            }

            result = fromUI;
            return result;
        }

        
    }
}
