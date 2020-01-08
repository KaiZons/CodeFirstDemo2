using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace ORMConfiguration
{
    public class ORMDbConfiguration : DbConfiguration
    {
        public ORMDbConfiguration()
        {
            var providerName = "System.Data.SqlServerCe.4.0";
            SetDefaultConnectionFactory(new SqlCeConnectionFactory(providerName));
            //关于EF调用sqlce的配置文件说明：https://blog.csdn.net/pksniq/article/details/25160095
            //因为用到了EF，所以这里的entityFramework配置里面的invariantName与connectionStrings里面的providerName都要对应为DbProviderFactories里面注册的名字invariant="System.Data.SQLite"，否则会提示没有注册System.Data.SQLite。
        }
    }
}
