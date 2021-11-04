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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Filter { get; set; }
        public bool IsHidden { get; set; }
        public int TransactionTypeID { get; set; }
        public int TransactionCategoryID { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public decimal ReceiptAmount { get; set; }
        public decimal ExpenditureAcount { get; set; }
        public virtual IdentityUser User { get; set; }
        public virtual TransactionCategoryDto TransactionCategory { get; set; } = new TransactionCategoryDto();
        public virtual TransactionTypeDto TransactionType { get; set; }
    }
}
