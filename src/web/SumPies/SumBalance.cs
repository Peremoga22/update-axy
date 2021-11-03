using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.SumPies
{
    public class SumBalance : SumPieBase
    {
        public string SumPercentage => this.SumReceipt - this.SumExpenditure + "";
    }
}
