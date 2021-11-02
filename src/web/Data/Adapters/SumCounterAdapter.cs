using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using web.Data.Helpers;
using web.Data.ModelDtos;

namespace web.Data.Adapters
{
    public static class SumCounterAdapter
    {
        public static decimal GetCurrentSum(int transactionTypeID)
        {
            decimal currentBalance = 0;

            var sql = string.Format(@"EXEC [sp_GetCalculatedSum] {0}",           
          
            DataBaseHelper.RawSafeSqlString(transactionTypeID));
            var sqlResult = DataBaseHelper.GetSqlResult(sql);

            if (sqlResult.Rows.Count > 0)
            {
                currentBalance = DataBaseHelper.GetDecimalValueFromRowByName(sqlResult.Rows[0], "CurrentSum");
            }

            return currentBalance;
        }

    }
}
