using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.SumPies
{
    public class SumExpenditure : SumPieBase
    {
        public string SumPercentage2 => this.SumExpenditure - this.SumReceipt + "";
    }
}
