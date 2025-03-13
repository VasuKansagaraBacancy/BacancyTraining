namespace EF_CORE_Day4.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
