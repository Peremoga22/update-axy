using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace web.EF.Models
{
    public class TransactionCategory : BasicModel
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int ActiveTransactionsCount { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal ExpectedAmount { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
