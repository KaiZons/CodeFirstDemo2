using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseUpgrade
{
    public class MigratorManager
    {
        public static void Migrate()
        {
            UpgradeSql upgradeSql = new UpgradeSql();
            List<string> sqls = upgradeSql.GetUpgradeSql();
            DataAccess.ExecuteSqlGroupsInTransaction(sqls);
        }
    }
}
