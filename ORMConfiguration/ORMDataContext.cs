using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ORMConfiguration
{
    public class ORMDataContext: DbContext
    {
        public ORMDataContext() : base(ConnectionStrings.CurrentConnectionString) { }

        public virtual DbSet<FixedSalaryEntity> FixedSalaries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => type.BaseType != null
                    && type.BaseType.IsGenericType
                    && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
        }
    }
}
