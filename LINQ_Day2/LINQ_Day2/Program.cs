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
        employeeManagement.QueryReport(employees, attendances);

        employeeManagement.MethodEmployeeAttendance(employees,attendances);
        employeeManagement.QueryEmployeeAttendance(employees, attendances);

        employeeManagement.MethodAllAttendanceRecords(employees, attendances);
        employeeManagement.QueryAllAttendanceRecords(employees, attendances);

        employeeManagement.MethodAttendanceRecords(employees, attendances);
        employeeManagement.QueryAttendanceRecords(employees, attendances);

        employeeManagement.MethodAttendanceSummary(employees, attendances);
        employeeManagement.QueryAttendanceSummary(employees, attendances);

        employeeManagement.MethodAlterAttendanceSummary(employees, attendances);
        employeeManagement.QueryAlterAttendanceSummary(employees, attendances);

        employeeManagement.MethodEmployeesWithMinimumAttendance(employees, attendances,2,2024);
        employeeManagement.QueryEmployeesWithMinimumAttendance(employees, attendances, 2, 2024);

        employeeManagement.MethodUniqueDepartment(employees);
        employeeManagement.QueryUniqueDepartment(employees);

        employeeManagement.MethodMerge(employees,otheremployees);
        employeeManagement.QueryMerge(employees, otheremployees);

        employeeManagement.MethodIntersect(employees, otheremployees);
        employeeManagement.QueryIntersect(employees, otheremployees);

        employeeManagement.MethodFirst(employees, otheremployees);
        employeeManagement.QueryFirst(employees, otheremployees);

        employeeManagement.MethodDeferred(employees);
        employeeManagement.QueryDeferred(employees);

        employeeManagement.MethodImmediate(employees);
        employeeManagement.QueryImmediate(employees);
    }
}