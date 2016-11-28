using Emp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Data.Configurations
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            HasKey(p => p.ID);
            Property(p => p.FirstName).HasMaxLength(100);
            //Property(p => p.LastName).HasMaxLength(100);
        }
    }
}
