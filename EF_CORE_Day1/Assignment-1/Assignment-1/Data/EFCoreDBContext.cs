using Assignment_1.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_1.Data
{
    public class EFCoreDBContext : DbContext
    {
        public EFCoreDBContext()
        {           
        }
        public DbSet<Student> Students { get; set; }
    }
}
