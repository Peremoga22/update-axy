using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.EF.Models
{
    public class TransactionType : BasicModel
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
