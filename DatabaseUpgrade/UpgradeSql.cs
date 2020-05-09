using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseUpgrade
{
    public class UpgradeSql
    {
        private List<string> m_upgradeSql = new List<string>();
        public List<string> GetUpgradeSql()
        {
            m_upgradeSql.Clear();
            CreateFixedSalariesTable();
            return m_upgradeSql;
        }

        private void CreateFixedSalariesTable()
        {
            m_upgradeSql.Add(@"CREATE TABLE FixedSalaries (
	                        PKFixedSalary UNIQUEIDENTIFIER NOT NULL PRIMARY KEY
	                        ,PKObject uniqueidentifier NOT NULL
	                        ,Name nvarchar(32) NOT NULL
	                        ,Amount numeric(12, 2) NOT NULL
	                        ,SortValue smallint NOT NULL
	                        ,DeleteStatus bit DEFAULT 0 NOT NULL
                            ,PKCompany uniqueidentifier NOT NULL
	                        )");
        }
    }
}
