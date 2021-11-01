using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using web.Data.Helpers;
using web.Data.ModelDtos;

namespace web.Data.Adapters
{
    public static class TransactionAdapter
    {
        public static List<TransactionDto> GetTransaction(string userId)
        {
            var result = new List<TransactionDto>();

            string sql = null;
            sql = string.Format(@"exec [sp_GetTransaction]  {0}",
            DataBaseHelper.SafeSqlString(userId));
            var sqlResult = DataBaseHelper.GetSqlResult(sql);

            if (sqlResult.Rows.Count > 0)
            {
                foreach (DataRow item in sqlResult.Rows)
                {
                    result.Add(new TransactionDto
                    {
                        ID = DataBaseHelper.GetIntegerValueFromRowByName(item, "ID"),
                        Amount = DataBaseHelper.GetDecimalValueFromRowByName(item, "Amount"),
                        Note = DataBaseHelper.GetValueFromRowByName(item, "Note"),
                        TransactionDate = DataBaseHelper.GetDateTimeValueFromRowByName(item, "TransactionDate"),
                        IsHidden = DataBaseHelper.GetBoolValueFromRowByName(item, "IsHidden"),
                        TransactionTypeID = DataBaseHelper.GetIntegerValueFromRowByName(item, "TransactionTypeID"),
                        TransactionCategoryID = DataBaseHelper.GetIntegerValueFromRowByName(item, "TransactionCategoryID"),
                        IsActive = DataBaseHelper.GetBoolValueFromRowByName(item, "IsActive"),
                        Description = DataBaseHelper.GetValueFromRowByName(item, "DescriptionCategory")
                    });
                }
            }

            return result;
        }


        public static void SaveTransaction(TransactionDto model)
        {
            var sql = string.Empty;
            //var format = "yyyy-MM-dd HH:mm:ss:fff";
            //var stringDateTransaction = model.TransactionDate.ToString(format);
            if (model.ID > 0)
            {
                sql = string.Format(@"EXEC [sp_SaveTransaction] {0}, {1}, {2} ,{3}, {4}, {5},{6}",
                DataBaseHelper.RawSafeSqlString(model.ID),
                DataBaseHelper.RawSafeSqlString(model.Amount),
                DataBaseHelper.SafeSqlString(model.Note),
                DataBaseHelper.SafeSqlString(model.TransactionDate),                
                DataBaseHelper.SafeSqlString(model.User.Id),
                DataBaseHelper.RawSafeSqlString(model.TransactionCategory.ID),
                DataBaseHelper.RawSafeSqlString(model.TransactionType.ID));
                DataBaseHelper.RunSql(sql);               
            }
                        
            sql = string.Format(@"EXEC [sp_SaveTransaction] {0}, {1}, {2},{3}, {4}, {5},{6}",
            DataBaseHelper.RawSafeSqlString(model.ID),
            DataBaseHelper.RawSafeSqlString(model.Amount),
            DataBaseHelper.SafeSqlString(model.Note),
            DataBaseHelper.SafeSqlString(model.TransactionDate),           
            DataBaseHelper.SafeSqlString(model.User.Id),
            DataBaseHelper.RawSafeSqlString(model.TransactionCategory.ID),
            DataBaseHelper.RawSafeSqlString(model.TransactionType.ID));
            DataBaseHelper.RunSql(sql);           
        }

        public static void DeleteTransaction(int id)
        {
            if (id > 0)
            {
                string sql = string.Format(@"exec sp_DeleteTransaction {0}",
                DataBaseHelper.RawSafeSqlString(id));
                DataBaseHelper.RunSql(sql);
            }
        }

        public static TransactionDto GetTransactionId(int Id)
        {
            TransactionDto result = new TransactionDto();

            var sql = string.Format(@"EXEC [sp_TransactionID] {0}",
               DataBaseHelper.RawSafeSqlString(Id));
            var sqlResult = DataBaseHelper.GetSqlResult(sql);

            if (sqlResult.Rows.Count > 0)
            {
                result = new TransactionDto
                {
                    ID = DataBaseHelper.GetIntegerValueFromRowByName(sqlResult.Rows[0], " ID"),
                    Amount = DataBaseHelper.GetDecimalValueFromRowByName(sqlResult.Rows[0], "Amount"),
                    Note = DataBaseHelper.GetValueFromRowByName(sqlResult.Rows[0], "Note"),
                    TransactionDate = DataBaseHelper.GetDateTimeValueFromRowByName(sqlResult.Rows[0], "TransactionDate"),
                    IsActive =DataBaseHelper.GetBoolValueFromRowByName(sqlResult.Rows[0], "IsActive"),
                    Description = DataBaseHelper.GetValueFromRowByName(sqlResult.Rows[0], "DescriptionCategory")
                };
            }

            return result;
        }
    }
}
