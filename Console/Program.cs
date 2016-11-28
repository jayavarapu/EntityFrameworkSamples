using Emp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emp.Model;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Data.Common;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // CreateNewEmployee();

            //CreateEmployer();

            //getEmployees();

            //retriveEmployees();
            // RetrieveEmployeesInaRange();

            // GetEmployeeNameandEmployerName();
            GetEmployeeNameandEmployerNameESql();
        }

        private static void GetEmployeeNameandEmployerNameESql()
        {
            using (var context = new EmployeeDbContext())
            {
                string query = @"Select Employee.FirstName as EmployeeName, Employee.Employer as Employer from EmployeeDbContext.Employees as Employee";
                var adapter = (IObjectContextAdapter)context;
                var objectContext = adapter.ObjectContext;
                objectContext.Connection.Open();

                ObjectQuery<DbDataRecord> objectQuery = new ObjectQuery<DbDataRecord>(query, objectContext);
                List<EmployeeResult> lstEmployeeResult = new List<EmployeeResult>();

                foreach (DbDataRecord record in objectQuery)
                {
                    string employeeName = record[0] as string;
                    string EmployerName = string.Empty;
                    Employer employer = record[1] as Employer;
                    if (employer != null)
                    {
                        EmployerName = employer.Name;
                    }


                    lstEmployeeResult.Add(new EmployeeResult
                    {
                        EmployeeName = employeeName,
                        EmployerName = EmployerName
                    });
                }
                foreach(var item in lstEmployeeResult)
                {
                    Console.WriteLine("Employee Name: " + item.EmployeeName + "  EmployerName : " + item.EmployerName);
                }

            }
        }

        private static void GetEmployeeNameandEmployerName()
        {
            using (var context = new EmployeeDbContext())
            {
                var result = context.Employees.Select(employee => new EmployeeResult()
                {
                    EmployeeName = employee.FirstName,
                    EmployerName = employee.Employer.Name
                });
                foreach (var item in result)
                {
                    Console.WriteLine("Employee Name: " + item.EmployeeName + "  EmployerName : " + item.EmployerName);
                }
            }
        }

        private static void RetrieveEmployeesInaRange()
        {
            ObjectParameter minValue = new ObjectParameter("minValue", 2);
            ObjectParameter maxValue = new ObjectParameter("maxValue", 8);
            using (var context = new EmployeeDbContext())
            {
                string query = @"select VALUE Employee from EmployeeDbContext.Employees as Employee where Employee.ID > @minValue and Employee.ID <@maxValue";

                var adapter = (IObjectContextAdapter)context;
                var objectContext = adapter.ObjectContext;

                ObjectQuery<Employee> objQuery = new ObjectQuery<Employee>(query, objectContext);
                objQuery.Parameters.Add(minValue);
                objQuery.Parameters.Add(maxValue);
                List<Employee> lstEmployees = objQuery.ToList();
            }
        }

        private static void retriveEmployees()
        {
            using (var context = new EmployeeDbContext())
            {
                string query = @"select VALUE Employee from EmployeeDbContext.Employees as Employee";

                var objectContext = ((IObjectContextAdapter)context).ObjectContext;
                objectContext.Connection.Open();
                ObjectQuery<Employee> objQuery = new ObjectQuery<Employee>(query, objectContext);
                List<Employee> lstEmployees = objQuery.ToList();


            }
        }

        private static void getEmployees()
        {
            using (var context = new EmployeeDbContext())
            {
                //var employees = context.Employees.Where(x => x.ID == 1);

                var employees = context.Employers.Where(x => x.Id == 1).Select(x => x.Employees).FirstOrDefault();
                var employer = context.Employees.Where(x => x.ID == 1).Select(x => x.Employer).FirstOrDefault();



            }
        }

        private static void CreateEmployer()
        {
            using (var context = new EmployeeDbContext())
            {
                var employer = new Employer()
                {
                    Name = "CTS",
                };
                context.Employers.Add(employer);
                context.SaveChanges();
            }
        }

        private static void CreateNewEmployee()
        {
            using (var context = new EmployeeDbContext())
            {
                var employee = new Employee()
                {
                    //Email = "test@123.com",
                    FirstName = "testFirstName",
                    //LastName = "testLastName",
                    //PhoneNumber = "7878787888",
                    //Salary = 1234m
                };
                context.Employees.Add(employee);
                context.SaveChanges();

            }
        }
    }
}
