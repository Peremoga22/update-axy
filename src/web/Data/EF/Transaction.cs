using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

namespace web.EF.Models
{
    public class Transaction : BasicModel
    {
        public int ID { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime DateRemoved { get; set; }
        public bool IsHidden { get; set; }
        public virtual IdentityUser User{ get; set; }
        public virtual TransactionCategory TransactionCategory { get; set; }
        public virtual TransactionType TransactionType { get; set; }
    }
}
