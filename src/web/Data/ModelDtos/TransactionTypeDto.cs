using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Data.ModelDtos
{
    public class TransactionTypeDto
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
