using EF_CORE_Day4.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_CORE_Day4.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId);

            
            modelBuilder.Entity<EmployeeProject>()
                .HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(ep => ep.EmployeeId);

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Project)
                .WithMany(p => p.EmployeeProjects)
                .HasForeignKey(ep => ep.ProjectId);

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "Human Resources" },
                new Department { DepartmentId = 2, DepartmentName = "Information Technology" },
                new Department { DepartmentId = 3, DepartmentName = "Finance" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, Name = "Vasu Kansagara", Email = "Vasu.kansagara@bacancy.com", DepartmentId = 1 },
                new Employee { EmployeeId = 2, Name = "Bob Smith", Email = "bob.smith@example.com", DepartmentId = 2 },
                new Employee { EmployeeId = 3, Name = "Charlie Brown", Email = "charlie.brown@example.com", DepartmentId = 2 },
                new Employee { EmployeeId = 4, Name = "Diana Prince", Email = "diana.prince@example.com", DepartmentId = 3 }
            );

            modelBuilder.Entity<Project>().HasData(
                new Project { ProjectId = 1, ProjectName = "HR Onboarding System", StartDate = new DateTime(2024, 1, 10) },
                new Project { ProjectId = 2, ProjectName = "Website Redesign", StartDate = new DateTime(2024, 2, 15) },
                new Project { ProjectId = 3, ProjectName = "Financial Audit Automation", StartDate = new DateTime(2024, 3, 1) }
            );

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject { EmployeeId = 1, ProjectId = 1, Role = "Project Manager" },
                new EmployeeProject { EmployeeId = 2, ProjectId = 2, Role = "Lead Developer" },
                new EmployeeProject { EmployeeId = 3, ProjectId = 2, Role = "UI/UX Designer" },
                new EmployeeProject { EmployeeId = 4, ProjectId = 3, Role = "Financial Analyst" },
                new EmployeeProject { EmployeeId = 2, ProjectId = 3, Role = "Data Engineer" }
            );
        }
    }
}
