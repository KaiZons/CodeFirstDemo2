using ORMConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class DataAccess
    {
        private static string SqlConnString 
        { 
            get 
            { 
                return ConnectionStrings.CurrentConnectionString; 
            } 
        }

        public static bool ExecuteSqlGroupsInTransaction(List<string> sqlGroups)
        {
            if (sqlGroups == null || sqlGroups.Count == 0)
            {
                return true;
            }
            int step = 250;
            List<string> sqlGroupsToRun;
            string sqlCurrent = String.Empty;
            try
            {
                while (sqlGroups.Count > 0)
                {
                    int count = Math.Min(sqlGroups.Count, step);
                    if (count < step)
                    {
                        sqlGroupsToRun = sqlGroups;
                    }
                    else
                    {
                        sqlGroupsToRun = sqlGroups.GetRange(0, count);
                    }
                    ExecuteSqlGroupsInTransaction(sqlGroupsToRun, ref sqlCurrent);
                    sqlGroups.RemoveRange(0, count);
                }
                return true;
            }
            catch (Exception e)
            {
                SqlServerExceptionHandler(e, sqlCurrent);
                return false;
            }
        }

        private static void ExecuteSqlGroupsInTransaction(List<string> sqlGroupsToRun, ref string sqlCurrent)
        {
            using (SqlCeConnection connection = GetSqlConnection())
            {
                connection.Open();
                using (SqlCeTransaction transaction = connection.BeginTransaction())
                {
                    using (SqlCeCommand command = new SqlCeCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        command.Transaction = transaction;
                        foreach (var sql in sqlGroupsToRun)
                        {
                            sqlCurrent = sql;
                            ExecuteSql(command, sql);
                        }
                    }
                    transaction.Commit();
                }
            }
        }

        private static void ExecuteSql(SqlCeCommand command, string sql)
        {
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        private static SqlCeConnection GetSqlConnection()
        {
            try
            {
                return new SqlCeConnection(SqlConnString);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void SqlServerExceptionHandler(Exception ex, string sql)
        {
            Utilities.Logger.WriteError(ex, "SQLError", sql + "异常");
        }
    }
}
