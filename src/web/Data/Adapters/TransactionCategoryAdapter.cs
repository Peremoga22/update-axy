using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using web.Data.Helpers;
using web.Data.ModelDtos;

namespace web.Data.Adapters
{
    public static class TransactionCategoryAdapter
    {
        public static List<TransactionCategoryDto> GetTransactionCategories(string userId)
        {
            var result = new List<TransactionCategoryDto>();

            string sql = null;
            sql = string.Format(@"exec [sp_GetTransactionCategory]  {0}",
            DataBaseHelper.SafeSqlString(userId));
            var sqlResult = DataBaseHelper.GetSqlResult(sql);

            if (sqlResult.Rows.Count > 0)
            {
                foreach (DataRow item in sqlResult.Rows)
                {
                    result.Add(new TransactionCategoryDto
                    {
                        ID = DataBaseHelper.GetIntegerValueFromRowByName(item, "ID"),
                        Description = DataBaseHelper.GetValueFromRowByName(item, "Description"),
                        IsActive = DataBaseHelper.GetBoolValueFromRowByName(item, "IsActive"),
                        ActiveTransactionsCount = DataBaseHelper.GetIntegerValueFromRowByName(item, "ActiveTransactionsCount"),
                        ExpectedAmount = DataBaseHelper.GetDecimalValueFromRowByName(item, "ExpectedAmount"),
                        TransactionTypeID = DataBaseHelper.GetIntegerValueFromRowByName(item, "TransactionTypeID")
                    });
                }
            }

            return result;
        }

        public static int SaveTransactionCategory(TransactionCategoryDto model)
        {
            var sql = string.Empty;
            if (model.ID > 0)
            {
                sql = string.Format(@"EXEC [sp_SaveTransactionCategory] {0}, {1}, {2} ,{3}, {4}, {5}",
                DataBaseHelper.RawSafeSqlString(model.ID),
                DataBaseHelper.SafeSqlString(model.Description),
                DataBaseHelper.SafeSqlString(model.IsActive),
                DataBaseHelper.RawSafeSglDecimal(model.ExpectedAmount),
                DataBaseHelper.RawSafeSqlString(model.TransactionType.ID),
                DataBaseHelper.SafeSqlString(model.User.Id));

                DataBaseHelper.RunSql(sql);
                return 0;
            }

            var TransactionCategoryId = 0;
            sql = string.Format(@"EXEC [sp_SaveTransactionCategory] {0}, {1}, {2} ,{3}, {4}, {5}",
            DataBaseHelper.RawSafeSqlString(model.ID),
            DataBaseHelper.SafeSqlString(model.Description),
            DataBaseHelper.SafeSqlString(model.IsActive),
            DataBaseHelper.RawSafeSglDecimal(model.ExpectedAmount),
            DataBaseHelper.RawSafeSqlString(model.TransactionType.ID),
            DataBaseHelper.SafeSqlString(model.User.Id));

            var dataResult = DataBaseHelper.GetSqlResult(sql);
            if (dataResult != null && dataResult.Rows.Count > 0)
            {
                foreach (DataRow row in dataResult.Rows)
                {
                    TransactionCategoryId = DataBaseHelper.GetIntegerValueFromRowByName(dataResult.Rows[0], "ID");
                }
            }

            return TransactionCategoryId;
        }

        public static TransactionCategoryDto GetTransactionCategoryId(int Id)
        {
            TransactionCategoryDto result = new TransactionCategoryDto();

            var sql = string.Format(@"EXEC [sp_TransactionCategoryID] {0}",
               DataBaseHelper.RawSafeSqlString(Id));
            var sqlResult = DataBaseHelper.GetSqlResult(sql);

            if (sqlResult.Rows.Count > 0)
            {
                result = new TransactionCategoryDto
                {
                    ID = DataBaseHelper.GetIntegerValueFromRowByName(sqlResult.Rows[0], "ID"),
                    Description = DataBaseHelper.GetValueFromRowByName(sqlResult.Rows[0], "Description"),                  
                    IsActive = DataBaseHelper.GetBoolValueFromRowByName(sqlResult.Rows[0], "IsActive"),
                    ActiveTransactionsCount = DataBaseHelper.GetIntegerValueFromRowByName(sqlResult.Rows[0], "ActiveTransactionsCount"),                  
                    ExpectedAmount = DataBaseHelper.GetDecimalValueFromRowByName(sqlResult.Rows[0], "ExpectedAmount")
                };
            }

            return result;
        }

        public static void DeleteTransactionCategory(int id)
        {
            if (id > 0)
            {
                string sql = string.Format(@"exec sp_DeleteTransactionCategory {0}",
                DataBaseHelper.RawSafeSqlString(id));
                DataBaseHelper.RunSql(sql);
            }
        }
    }
}
