using Microsoft.AspNetCore.Identity;
using System;

namespace web.Data.ModelDtos.ModelDataCast
{   
    public class TransactionDataCast
    {
        public int ID { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public DateTime TransactionDate { get; set; }            
        public bool IsHidden { get; set; }
        public int TransactionTypeID { get; set; }
        public int TransactionCategoryID { get; set; }
        public bool IsActive { get; set; }    
        public string UserID { get; set; }
    }
}
