namespace EF_CORE_Day4.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }

        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
