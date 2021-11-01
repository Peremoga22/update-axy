using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Data.ModelDtos
{
    public class TransactionDto
    {
        public int ID { get; set; }       
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime DateRemoved { get; set; }
        public bool IsHidden { get; set; }
        public virtual IdentityUser User { get; set; }
        public virtual TransactionCategoryDto TransactionCategory { get; set; } = new TransactionCategoryDto();
        public virtual TransactionTypeDto TransactionType { get; set; }
    }
}
