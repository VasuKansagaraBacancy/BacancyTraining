using Assignment_2.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Assignment_2.Data
{
    public class EFCoreDBContext : DbContext
    {
        public EFCoreDBContext(DbContextOptions<EFCoreDBContext> options) : base(options)
        {
        }
        public DbSet<Student> AllStudents { get; set; }
    }
}
