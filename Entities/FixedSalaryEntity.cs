using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class FixedSalaryEntity
    {
        public FixedSalaryEntity() { }
        public Guid PKFixedSalary { get; set; }
        public Guid PKObject { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public short SortValue { get; set; }
        public bool DeleteStatus { get; set; }
        public Guid PKCompany { get; set; }
    }
}
