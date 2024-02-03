using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class Employee
    {
        public Employee(string lastName, string firstName, string title)
        {
            LastName = lastName;
            FirstName = firstName;
            Title = title;
        }

        public string LastName { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string Title { get; set; } = default!;
    }
}
