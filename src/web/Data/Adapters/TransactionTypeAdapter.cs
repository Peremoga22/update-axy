using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using web.Data.Helpers;
using web.Data.ModelDtos;

namespace web.Data.Adapters
{
    public static class TransactionTypeAdapter
    {
        public static List<TransactionTypeDto> GetTransactionType(string userId)
        {
            var result = new List<TransactionTypeDto>();

            string sql = null;
            sql = string.Format(@"exec [sp_GetTransactionTypes]  {0}",
            DataBaseHelper.SafeSqlString(userId));
            var sqlResult = DataBaseHelper.GetSqlResult(sql);

            if (sqlResult.Rows.Count > 0)
            {
                foreach (DataRow item in sqlResult.Rows)
                {
                    result.Add(new TransactionTypeDto
                    {
                        ID = DataBaseHelper.GetIntegerValueFromRowByName(item, "ID"),                       
                        Description = DataBaseHelper.GetValueFromRowByName(item, "Description"),                       
                        IsActive = DataBaseHelper.GetBoolValueFromRowByName(item, "IsActive")                        
                    });
                }
            }

            return result;
        }

        public static int SaveTransactionType(TransactionTypeDto model)
        {
            var sql = string.Empty;
            if (model.ID > 0)
            {               
                sql = string.Format(@"EXEC [sp_SaveTransactionType] {0}, {1}, {2}",
                DataBaseHelper.RawSafeSqlString(model.ID),               
                DataBaseHelper.SafeSqlString(model.Description),               
                DataBaseHelper.SafeSqlString(model.IsActive));

                DataBaseHelper.RunSql(sql);
                return 0;
            }

            var TransactionTypeId = 0;
            sql = string.Format(@"EXEC [sp_SaveTransactionType] {0}, {1}, {2}",
            DataBaseHelper.RawSafeSqlString(model.ID),
            DataBaseHelper.SafeSqlString(model.Description),
            DataBaseHelper.SafeSqlString(model.IsActive));

            var dataResult = DataBaseHelper.GetSqlResult(sql);
            if (dataResult != null && dataResult.Rows.Count > 0)
            {
                foreach (DataRow row in dataResult.Rows)
                {
                    TransactionTypeId = DataBaseHelper.GetIntegerValueFromRowByName(dataResult.Rows[0], "ID");
                }
            }

            return TransactionTypeId;
        }

      
    }
}
