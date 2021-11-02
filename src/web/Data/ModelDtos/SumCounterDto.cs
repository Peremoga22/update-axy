using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Data.ModelDtos
{
    public class SumCounterDto
    {
        public int ID { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal SavingForThisMounth { get; set; }
        public decimal BalanceTheBeginningMounth { get; set; }
    }
}
