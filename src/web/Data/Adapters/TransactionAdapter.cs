using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using web.Data.Helpers;
using web.Data.ModelDtos;

namespace web.Data.Adapters
{
    public class TransactionAdapter
    {
        public static void SaveTransaction(TransactionDto model)
        {
            var sql = string.Empty;
            var format = "yyyy-MM-dd HH:mm:ss:fff";
            var stringDateTransaction = model.TransactionDate.ToString(format);
            if (model.ID > 0)
            {
                sql = string.Format(@"EXEC [sp_SaveTransaction] {0}, {1}, {2} ,{3}, {4}, {5},{6}",
                DataBaseHelper.RawSafeSqlString(model.ID),
                DataBaseHelper.RawSafeSqlString(model.Amount),
                DataBaseHelper.SafeSqlString(model.Note),
                DataBaseHelper.SafeSqlString(stringDateTransaction),                
                DataBaseHelper.SafeSqlString(model.User.Id),
                DataBaseHelper.RawSafeSqlString(model.TransactionCategory.ID),
                DataBaseHelper.RawSafeSqlString(model.TransactionType.ID));
                DataBaseHelper.RunSql(sql);               
            }
                        
            sql = string.Format(@"EXEC [sp_SaveTransaction] {0}, {1}, {2},{3}, {4}, {5},{6}",
            DataBaseHelper.RawSafeSqlString(model.ID),
            DataBaseHelper.RawSafeSqlString(model.Amount),
            DataBaseHelper.SafeSqlString(model.Note),
            DataBaseHelper.SafeSqlString(stringDateTransaction),           
            DataBaseHelper.SafeSqlString(model.User.Id),
            DataBaseHelper.RawSafeSqlString(model.TransactionCategory.ID),
            DataBaseHelper.RawSafeSqlString(model.TransactionType.ID));
            DataBaseHelper.RunSql(sql);           
        }
    }
}
