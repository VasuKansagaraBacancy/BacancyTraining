using LINQ_Day2;
class Program
{
    static void Main()
    {
        List<Employee> employees=Employee.GetEmployees();
        List<Employee> otheremployees = Employee.GetOtherEmployees();
        List<Attendance> attendances = Attendance.GetAttendances();
        EmployeeManagement employeeManagement = new EmployeeManagement();
        employeeManagement.MethodReport(employees,attendances);
        employeeManagement.MethodEmployeeAttendance(employees,attendances);
        employeeManagement.MethodAllAttendanceRecords(employees, attendances);
        employeeManagement.MethodAttendanceRecords(employees, attendances);
        employeeManagement.MethodAttendanceSummary(employees, attendances);
        employeeManagement.MethodAlterAttendanceSummary(employees, attendances);
        employeeManagement.MethodEmployeesWithMinimumAttendance(employees, attendances,2,2024);
        employeeManagement.MethodUniqueDepartment(employees);
        employeeManagement.MethodMerge(employees,otheremployees);
        employeeManagement.MethodIntersect(employees, otheremployees);
        employeeManagement.MethodFirst(employees, otheremployees);
        employeeManagement.MethodDeffered(employees);
        employeeManagement.MethodImmediate(employees);
    }
}