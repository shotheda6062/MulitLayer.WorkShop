using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.WorkShop.Infrastructure
{
    public class MemberFilterModel
    {
        public Guid? Id { get; set; }

        public int? WorkId { get; set; }

        public string CompanyName { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public bool? Admin { set; get; }

        public bool? Member { set; get; }

        public bool? Lock { set; get; }

    }
}
