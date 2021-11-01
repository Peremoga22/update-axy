using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Data.ModelDtos
{
    public class TransactionCategoryDto
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int ActiveTransactionsCount { get; set; }       
        public decimal ExpectedAmount { get; set; }
        public int TransactionTypeID { get; set; }
        public virtual TransactionTypeDto TransactionType { get; set; } = new TransactionTypeDto();
        public virtual IdentityUser User { get; set; }
    }
}
