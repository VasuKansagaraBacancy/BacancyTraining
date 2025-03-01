﻿using LINQ_Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Day2
{
    public class EmployeeManagement
    {
        public void MethodReport(List<Employee> employees, List<Attendance> attendances)
        {
            PrintHeader("A report that shows each employee’s name along with the dates they were present using Method Syntax.");
            if (employees == null || attendances == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var methodReport = employees.Join(attendances.Where(a => a.IsPresent),
                                              emp => emp.EmployeeId,
                                              att => att.EmployeeId,
                                              (emp, att) => new { emp.Name, att.Date })
                                              .GroupBy(emp => emp.Name)
                                              .Select(g => new
                                              {
                                                  EmployeeName = g.Key,
                                                  DatesPresent = g.Select(x => x.Date.ToShortDateString()).ToList()
                                              }).ToList();
            foreach (var item in methodReport)
            {
                Console.WriteLine($"Employee: {item.EmployeeName}");
                Console.WriteLine("Dates Present: " + string.Join(", ", item.DatesPresent));
                Console.WriteLine();
            }
        }
        public void QueryReport(List<Employee> employees, List<Attendance> attendances)
        {
            PrintHeader("A report that shows each employee’s name along with the dates they were present using Query Syntax.");
            if (employees == null || attendances == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var queryReport = (from emp in employees
                               join att in attendances.Where(a => a.IsPresent)
                               on emp.EmployeeId equals att.EmployeeId
                               group att by emp.Name into empGroup
                               select new
                               {
                                   EmployeeName = empGroup.Key,
                                   DatesPresent = empGroup.Select(x => x.Date.ToShortDateString()).ToList()
                               }).ToList();
            foreach (var item in queryReport)
            {
                Console.WriteLine($"Employee: {item.EmployeeName}");
                Console.WriteLine("Dates Present: " + string.Join(", ", item.DatesPresent));
                Console.WriteLine();
            }
        }
        public void MethodEmployeeAttendance(List<Employee> employees, List<Attendance> attendances)
        {
            PrintHeader("Each employee’s details, displaying their attendance records using Method Syntax.");
            if (employees == null || attendances == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var employeeAttendance = employees.GroupJoin(attendances,
                                                         emp => emp.EmployeeId,
                                                         att => att.EmployeeId,
                                                         (emp, att) => new
                                                         {
                                                             emp.EmployeeId,
                                                             emp.Name,
                                                             emp.Department,
                                                             AttendanceDates = att.Where(a => a.IsPresent)
                                                                                         .Select(a => a.Date.ToShortDateString())
                                                                                         .ToList()
                                                         }).ToList();
            foreach (var item in employeeAttendance)
            {
                Console.WriteLine($"Employee: {item.Name}, Department: {item.Department}");
                Console.WriteLine("Attendance Dates: " + (item.AttendanceDates.Any() ? string.Join(", ", item.AttendanceDates) : "No attendance records"));
                Console.WriteLine();
            }
        }
        public void QueryEmployeeAttendance(List<Employee> employees, List<Attendance> attendances)
        {
            PrintHeader("Each employee’s details, displaying their attendance records using Query Syntax.");
            if (employees == null || attendances == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var queryEmployeeAttendance = (from emp in employees
                                           join att in attendances on emp.EmployeeId equals att.EmployeeId into empAttGroup
                                           select new
                                           {
                                               emp.EmployeeId,
                                               emp.Name,
                                               emp.Department,
                                               AttendanceDates = empAttGroup.Where(a => a.IsPresent)
                                                                            .Select(a => a.Date.ToShortDateString())
                                                                            .ToList()
                                           }).ToList();
            foreach (var item in queryEmployeeAttendance)
            {
                Console.WriteLine($"Employee: {item.Name}, Department: {item.Department}");
                Console.WriteLine("Attendance Dates: " + (item.AttendanceDates.Any() ? string.Join(", ", item.AttendanceDates) : "No attendance records"));
                Console.WriteLine();
            }
        }
        public void MethodAllAttendanceRecords(List<Employee> employees, List<Attendance> attendances)
        {
            PrintHeader("A list that pairs all employees with all attendance records using Method Syntax.");
            if (employees == null || attendances == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var allAttendanceRecords = employees.Join(attendances,
                                        emp => emp.EmployeeId,
                                        att => att.EmployeeId,
                                        (emp, att) => new
                                        {
                                            emp.Name,
                                            emp.Department,
                                            att.Date,
                                            WasPresent = att.IsPresent ? "Present" : "Absent"
                                        }).ToList();
            foreach (var item in allAttendanceRecords)
            {
                Console.WriteLine($"Employee: {item.Name}\nDepartment: {item.Department}\nDate: {item.Date.ToShortDateString()}\nAttendance: {item.WasPresent}");
                Console.WriteLine("------------");
            }
        }
        public void QueryAllAttendanceRecords(List<Employee> employees, List<Attendance> attendances)
        {
            PrintHeader("A list that pairs all employees with all attendance records using Query Syntax.");
            if (employees == null || attendances == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var allAttendanceRecords = (from emp in employees
                                        join att in attendances
                                        on emp.EmployeeId equals att.EmployeeId
                                        select new
                                        {
                                            emp.Name,
                                            emp.Department,
                                            att.Date,
                                            WasPresent = att.IsPresent ? "Present" : "Absent"
                                        }).ToList();
            foreach (var item in allAttendanceRecords)
            {
                Console.WriteLine($"Employee: {item.Name} \nDepartment: {item.Department} \nDate: {item.Date.ToShortDateString()} \nAttendance: {item.WasPresent}");
                Console.WriteLine("------------");
            }
        }
        public void MethodAttendanceRecords(List<Employee> employees, List<Attendance> attendances)
        {
            PrintHeader("A list that pairs with no attendance records using Method Syntax.");
            if (employees == null || attendances == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var allAttendanceRecords = employees.GroupJoin(attendances,
                                                          emp => emp.EmployeeId,
                                                          att => att.EmployeeId,
                                                          (emp, att) => new
                                                          {
                                                              emp.Name,
                                                              emp.Department,
                                                              AttendanceRecords = att.DefaultIfEmpty() 
                                                          })
                                                 .SelectMany(
                                                          entry => entry.AttendanceRecords,
                                                          (entry, att) => new
                                                          {
                                                              entry.Name,
                                                              entry.Department,
                                                              Date = att?.Date.ToShortDateString() ?? "N/A",
                                                              WasPresent = att?.IsPresent == true ? "Present" : att == null ? "No Record" : "Absent"
                                                          }).ToList();
            foreach (var item in allAttendanceRecords)
            {
                Console.WriteLine($"Employee: {item.Name}\nDepartment: {item.Department}\nDate: {item.Date}\nAttendance: {item.WasPresent}");
                Console.WriteLine("------------");
            }
        }
        public void QueryAttendanceRecords(List<Employee> employees, List<Attendance> attendances)
        {
            PrintHeader("A list that pairs with no attendance records using Query Syntax.");
            if (employees == null || attendances == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var allAttendanceRecords =
                from emp in employees
                join att in attendances
                on emp.EmployeeId equals att.EmployeeId into attGroup
                from att in attGroup.DefaultIfEmpty() 
                select new
                {
                    emp.Name,
                    emp.Department,
                    Date = att != null ? att.Date.ToShortDateString() : "N/A",
                    WasPresent = att != null ? (att.IsPresent ? "Present" : "Absent") : "No Record"
                };
            foreach (var item in allAttendanceRecords)
            {
                Console.WriteLine($"Employee: {item.Name} \nDepartment: {item.Department} \nDate: {item.Date} \nAttendance: {item.WasPresent}");
                Console.WriteLine("------------");
            }
        }
        public void MethodAttendanceSummary(List<Employee> employees, List<Attendance> attendances)
        {
            PrintHeader("Attendance Summary using Method Syntax");
            if (employees == null || attendances == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var attendanceSummary = employees.GroupJoin(attendances,
                                                        emp => emp.EmployeeId,
                                                        att => att.EmployeeId,
                                                        (emp, att) => new
                                                        {
                                                            emp.Name,
                                                            emp.Department,
                                                            TotalDaysPresent = att.Count(att => att != null && att.IsPresent)
                                                        }).ToList();
            foreach (var record in attendanceSummary)
            {
                Console.WriteLine($"Employee: {record.Name} \nDepartment: {record.Department} \nTotal Days Present: {record.TotalDaysPresent}");
                Console.WriteLine("------------");
            }
        }
        public void QueryAttendanceSummary(List<Employee> employees, List<Attendance> attendances)
        {
            PrintHeader("Attendance Summary using Query Syntax");
            if (employees == null || attendances == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var attendanceSummary = (from emp in employees
                                     join att in attendances
                                     on emp.EmployeeId equals att.EmployeeId into att
                                     select new
                                     {
                                         emp.Name,
                                         emp.Department,
                                         TotalDaysPresent = att.Count(att => att.IsPresent)
                                     }).ToList();
            foreach (var record in attendanceSummary)
            {
                Console.WriteLine($"Employee: {record.Name}  \nDepartment: {record.Department} \nTotal Days Present: {record.TotalDaysPresent}");
                Console.WriteLine("------------");
            }
        }
        public void MethodAlterAttendanceSummary(List<Employee> employees, List<Attendance> attendances)
        {
            PrintHeader("Attendance Summary using alternative Method Syntax");
            if (employees == null || attendances == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var attendanceLookup = attendances.ToLookup(att => att.EmployeeId);
            var attendanceSummary = employees.Select(emp => new
            {
                emp.Name,
                emp.Department,
                TotalDaysPresent = attendanceLookup[emp.EmployeeId].Count(att => att.IsPresent)
            }).ToList();
            foreach (var record in attendanceSummary)
            {
                Console.WriteLine($"Employee: {record.Name} \nDepartment: {record.Department} \nTotal Days Present: {record.TotalDaysPresent}");
                Console.WriteLine("------------");
            }
        }
        public void QueryAlterAttendanceSummary(List<Employee> employees, List<Attendance> attendances)
        {
            PrintHeader("Attendance Summary using alternative Query Syntax");
            if (employees == null || attendances == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var attendanceLookup = attendances.ToLookup(att => att.EmployeeId);
            var attendanceSummary = (from emp in employees
                                     let empAttendance = attendanceLookup[emp.EmployeeId]
                                     select new
                                     {
                                         emp.Name,
                                         emp.Department,
                                         TotalDaysPresent = empAttendance.Count(att => att.IsPresent)
                                     }).ToList();
            foreach (var record in attendanceSummary)
            {
                Console.WriteLine($"Employee: {record.Name} \nDepartment: {record.Department} \nTotal Days Present: {record.TotalDaysPresent}");
                Console.WriteLine("------------");
            }
        }
        public void MethodEmployeesWithMinimumAttendance(List<Employee> employees, List<Attendance> attendances, int month, int year)
        {
            PrintHeader("Attendance Summary - Employees with at least 2 days of attendance using Method Syntax");
            if (employees == null || attendances == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var result = employees.Where(emp => attendances.Any(att => att.EmployeeId == emp.EmployeeId && att.Date.Month == month && att.Date.Year == year)) 
                                  .Select(emp => new
                                  {
                                      emp.Name,
                                      emp.Department,
                                      TotalDaysPresent = attendances.Count(att => att.EmployeeId == emp.EmployeeId 
                                                                           && att.Date.Month == month 
                                                                           && att.Date.Year == year 
                                                                           && att.IsPresent) 
                                  })
        .Where(emp => emp.TotalDaysPresent >= 2) 
        .ToList();
            foreach (var employee in result)
            {
                Console.WriteLine($"Employee: {employee.Name} \nDepartment: {employee.Department} \nTotal Days Present: {employee.TotalDaysPresent}");
                Console.WriteLine("------------");
            }
        }
        public void QueryEmployeesWithMinimumAttendance(List<Employee> employees, List<Attendance> attendances, int month, int year)
        {
            PrintHeader("Attendance Summary - Employees with at least 2 days of attendance using Query Syntax");
            if (employees == null || attendances == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var result =
                from emp in employees
                let totalDaysPresent =
                    (from att in attendances
                     where att.EmployeeId == emp.EmployeeId
                           && att.Date.Month == month
                           && att.Date.Year == year
                           && att.IsPresent
                     select att).Count()
                where totalDaysPresent >= 2
                select new
                {
                    emp.Name,
                    emp.Department,
                    TotalDaysPresent = totalDaysPresent
                };
            foreach (var employee in result)
            {
                Console.WriteLine($"Employee: {employee.Name} \nDepartment: {employee.Department} \nTotal Days Present: {employee.TotalDaysPresent}");
                Console.WriteLine("------------");
            }
        }
        public void MethodUniqueDepartment(List<Employee> employees)
        {
            PrintHeader("Unique Departments using Method Syntax.");
            if (employees == null )
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var uniqueDepartments = employees
                         .Select(emp => emp.Department)
                         .Distinct()
                         .ToList();
            foreach (var department in uniqueDepartments)
            {
                Console.WriteLine($"Department: {department}");
            }
        }
        public void QueryUniqueDepartment(List<Employee> employees)
        {
            PrintHeader("Unique Departments using Query Syntax.");
            if (employees == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var uniqueDepartments = (from emp in employees
                                     select emp.Department)
                                     .Distinct()
                                     .ToList();
            foreach (var department in uniqueDepartments)
            {
                Console.WriteLine($"Department: {department}");
            }
        }
        public void MethodMerge(List<Employee> employees, List<Employee> otheremployees)
        {
            PrintHeader("Merge two lists of employees using Method Syntax.");
            if (employees == null || otheremployees == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var mergedEmployees = employees
           .Concat(otheremployees)
           .DistinctBy(emp => emp.Name) 
           .ToList();
            foreach (var emp in mergedEmployees)
            {
                Console.WriteLine(emp.Name);
            }
        }
        public void QueryMerge(List<Employee> employees, List<Employee> otheremployees)
        {
            PrintHeader("Merge two lists of employees using Query Syntax.");
            if (employees == null || otheremployees == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var mergedEmployees = (from emp in employees.Concat(otheremployees)
                                   group emp by emp.Name into empGroup
                                   select empGroup.FirstOrDefault())
                                  .ToList();
            foreach (var emp in mergedEmployees)
            {
                Console.WriteLine(emp.Name);
            }
        }
        public void MethodIntersect(List<Employee> employees, List<Employee> otheremployees)
        {
            PrintHeader("Intersect two lists of employees using Method Syntax.");
            if (employees == null || otheremployees == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }

            var commonEmployees = employees
                .IntersectBy(otheremployees.Select(emp => emp.Name), emp => emp.Name)
                .ToList();

            foreach (var emp in commonEmployees)
            {
                Console.WriteLine(emp.Name);
            }
        }
        public void QueryIntersect(List<Employee> employees, List<Employee> otheremployees)
        {
            PrintHeader("Intersect two lists of employees using Query Syntax.");
            if (employees == null || otheremployees == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var commonEmployees = (from emp1 in employees
                                   join emp2 in otheremployees
                                   on emp1.Name equals emp2.Name
                                   select emp1).ToList();
            foreach (var emp in commonEmployees)
            {
                Console.WriteLine(emp.Name);
            }
        }
        public void MethodFirst(List<Employee> employees, List<Employee> otheremployees)
        {
            PrintHeader("Employees present in the first list but not in the second using Method Syntax.");
            if (employees == null || otheremployees == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var uniqueEmployees = employees.ExceptBy(otheremployees
                                           .Select(emp => emp.Name), emp => emp.Name).ToList();
            foreach (var emp in uniqueEmployees)
            {
                Console.WriteLine(emp.Name);
            }
        }
        public void QueryFirst(List<Employee> employees, List<Employee> otheremployees)
        {
            PrintHeader("Employees present in the first list but not in the second using Query Syntax.");
            if (employees == null || otheremployees == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var uniqueEmployees = (from emp in employees
                                   where !(from other in otheremployees
                                           select other.Name)
                                          .Contains(emp.Name)
                                   select emp).ToList();
            foreach (var emp in uniqueEmployees)
            {
                Console.WriteLine(emp.Name);
            }
        }
        public void MethodDeferred(List<Employee> employees)
        {
            PrintHeader("Deffered execution example using Method Syntax."); 
            if (employees == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var employeeNamesQuery = employees.Select(emp => emp.Name);  
            employees.Add(new Employee(11, "Karan", "IT")); 
            foreach (var name in employeeNamesQuery)
            {
                Console.WriteLine(name);
            }
        }
        public void QueryDeferred(List<Employee> employees)
        {
            PrintHeader("Deffered execution example using Query Syntax.");
            if (employees == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var employeeNamesQuery = from emp in employees
                                     select emp.Name;
            employees.Add(new Employee(11, "Karan", "IT"));
            foreach (var name in employeeNamesQuery)
            {
                Console.WriteLine(name);
            }
        }
        public void MethodImmediate(List<Employee> employees)
        {
            PrintHeader("Immediate execution example using Method Syntax.");
            if (employees == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var employeeNamesQuery = employees.Select(emp => emp.Name).ToList();
            employees.Add(new Employee(11, "Karan", "IT"));
            foreach (var name in employeeNamesQuery)
            {
                Console.WriteLine(name);
            }
        }
        public void QueryImmediate(List<Employee> employees)
        {
            PrintHeader("Immediate execution example using Query Syntax.");
            if (employees == null)
            {
                Console.WriteLine("Invalid input data.");
                return;
            }
            var employeeNamesQuery = (from emp in employees
                                      select emp.Name).ToList();
            employees.Add(new Employee(11, "Karan", "IT"));
            foreach (var name in employeeNamesQuery)
            {
                Console.WriteLine(name);
            }
        }
        private void PrintHeader(string title)
        {
            Console.WriteLine(new string('-', 25)); 
            Console.WriteLine(title);
            Console.WriteLine(new string('-', 25));
        }
    }
}