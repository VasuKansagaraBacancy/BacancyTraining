using Assignment_1.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_1.Data
{
    public class EFCoreDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-JQ3SQMP\\SQLEXPRESS01;Database=School;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<Student> StudentsUsingConfig { get; set; }
    }
}
