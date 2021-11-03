using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.SumPies
{
    public class SumPieBase
    {
        public int TransactionId { get; set; }
        public string Note { get; set; }
        public decimal SumReceipt { get; set; }
        public decimal SumExpenditure { get; set; }
    }
}
