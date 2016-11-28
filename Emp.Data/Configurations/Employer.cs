using Emp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Data.Configurations
{
    public class EmployerConfigurations : EntityTypeConfiguration<Employer>
    {
        public EmployerConfigurations()
        {
            HasKey(p => p.Id);
            Property(p => p.Name).HasMaxLength(100);

            HasMany(x => x.Employees)
                .WithOptional(p => p.Employer);
        }

    }
}
