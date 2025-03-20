using Medicare__.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Medicare__.DatabaseContext
{
    public class MedicareDbContext : DbContext
    {
        public MedicareDbContext(DbContextOptions<MedicareDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientNote> PatientNotes { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Doctor>().HasQueryFilter(u => !u.IsDeleted);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Receptionist>().HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<UserRefreshToken>()
               .HasOne(rt => rt.User)
               .WithMany(u => u.UserRefreshTokens)
               .HasForeignKey(rt => rt.UserId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
