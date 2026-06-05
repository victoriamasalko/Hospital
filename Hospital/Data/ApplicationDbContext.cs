using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;

namespace Hospital.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<AdmissionHistory> AdmissionHistories { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<PatientMedication> PatientMedications { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PatientMedication>()
                .HasKey(x => new { x.PatientId, x.MedicationId });
            modelBuilder.Entity<PatientMedication>()
                .HasOne(p => p.Patient)
                .WithMany(pm => pm.PatientMedications)
                .HasForeignKey(fk => fk.PatientId);
            modelBuilder.Entity<PatientMedication>()
                .HasOne(m => m.Medication)
                .WithMany(pm => pm.PatientMedications)
                .HasForeignKey(fk => fk.MedicationId);

        }
    }
}
