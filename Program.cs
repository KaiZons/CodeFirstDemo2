using DatabaseUpgrade;
using ORMConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ORM
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitORMConnectionString();//初始化连接字符串
            //MigratorManager.Migrate();//升级数据库
            Application.Run(new Form1());
        }

        private static void InitORMConnectionString()
        {
            string databaseName = "LocalDatabase";
            string databasePwd = "zhoukaikai#123";
            int maxSize = 1024;
            ConnectionStrings.CurrentConnectionString = $@"Data Source={Application.StartupPath}\{databaseName}.sdf;Password={databasePwd};" + $@"Max Database Size={maxSize}";
        }
    }
}
