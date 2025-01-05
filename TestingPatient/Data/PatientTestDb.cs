using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestingPatient.Models;

namespace TestingPatient.Data
{
    public class PatientTestDb : IdentityDbContext<User>
    {
        public PatientTestDb(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<MedicalRecord> MedicalRecords { get; set; }

        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<Billing> Billings { get; set; }

        public DbSet<User> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Patient>()
        //        .HasMany(p => p.Appointments)
        //        .WithOne(a => a.Patient)
        //        .HasForeignKey(a => a.PatientId);

        //    modelBuilder.Entity<Doctor>()
        //        .HasMany(d => d.Appointments)
        //        .WithOne(a => a.Doctor)
        //        .HasForeignKey(a => a.DoctorId);
        //}
    }
}
