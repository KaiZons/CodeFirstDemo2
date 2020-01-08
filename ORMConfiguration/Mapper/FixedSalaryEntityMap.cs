using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace ORMConfiguration.Mapper
{
    public class FixedSalaryEntityMap: EntityTypeConfiguration<FixedSalaryEntity>
    {
        public FixedSalaryEntityMap()
        {
            ToTable("FixedSalaries");

            HasKey(p => p.PKFixedSalary);
            Property(p => p.PKObject).IsRequired();
            Property(p => p.Name).IsRequired();
            Property(p => p.Amount).IsRequired();
            Property(p => p.SortValue).IsRequired();
            Property(p => p.DeleteStatus).IsRequired();
            Property(p => p.PKCompany).IsRequired();
        }
    }
}
