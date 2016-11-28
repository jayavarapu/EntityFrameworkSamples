using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Model
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public decimal Salary { get; set; }
        //public string PhoneNumber { get; set; }
        //public string Email { get; set; }
        public Employer Employer { get; set; }
    }
}
