using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Day2
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public Employee(int employeeId, string name, string department)
        {
            EmployeeId = employeeId;
            Name = name;
            Department = department;
        }
        public static List<Employee> GetEmployees()
        {
            return new List<Employee>
        {
           new Employee(1, "Vasu", "IT"),
           new Employee(2, "Bhavya", "HR"),
           new Employee(3, "Chirag", "IT"),
           new Employee(4, "Deepak", "Finance"),
           new Employee(5, "Esha", "Marketing"),
           new Employee(6, "Divya", "HR"),
           new Employee(7, "Gaurav", "IT"),
           new Employee(8, "Himani", "Finance"),
           new Employee(9, "Ishita", "Marketing"),
           new Employee(10, "Jayesh", "IT")
        };
        }
        public static List<Employee> GetOtherEmployees()
        {
            return new List<Employee>
        {
           new Employee(1, "Vasu", "IT"),
           new Employee(2, "Raju", "HR"),
           new Employee(3, "Kaju", "IT"),
           new Employee(4, "Shubh", "Finance"),
           new Employee(5, "Eshani", "Marketing"),
           new Employee(6, "Divy", "HR"),
           new Employee(7, "Saurav", "IT"),
           new Employee(8, "Jimit", "Finance"),
           new Employee(9, "Ishika", "Marketing"),
           new Employee(10, "Jayesh", "IT")
        };
        }
    }
}