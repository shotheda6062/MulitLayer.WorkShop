using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.WorkShop.Infrastructure.ViewModel
{
    public class MemberListViewModel
    {
        public Guid Id  { set; get; }

        public string CompanyName { set; get; }

        public string CompanyId { set; get; }

        public int WorkId { set; get; }

        public string Name { set; get; }

        public string Email { set; get; }

        public bool? Admin { set; get; }

        public bool? Member { set; get; }

        public bool? Lock { set; get; }

        public DateTime? LastLoginDateTime { set; get; }

        public DateTime? LastModifyPasswordDate { set; get; }

        public string Remark { set; get; }

    }
}
