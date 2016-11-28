using Emp.Data.Configurations;
using Emp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext() : base("name=EmployeeDbContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<EmployeeDbContext>());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employer> Employers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new EmployerConfigurations());
        }
    }
}
