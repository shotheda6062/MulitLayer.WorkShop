using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.WorkShop.Infrastructure
{
    public class GridState
    {
        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int Skip { get; set; }

        public int TotalCount { get; set; }

        public int PageCount { get; set; }
    }
}
