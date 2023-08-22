using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class ManagementContext : DbContext
    {
        public ManagementContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<BloodTest> BloodTests { get; set; }
        public DbSet<CardiacCatheterizationStudy> CardiacCatheterizationStudies { get; set; }
        public DbSet<Diagnostic> Diagnostics { get; set; }
        public DbSet<DiseaseHistory> DiseaseHistories { get; set; }
        public DbSet<Echocardiogram> Echocardiograms { get; set; }
        public DbSet<Electrocardiogram> Electrocardiograms { get; set; }
        public DbSet<HolterStudy> HolterStudies { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<PhysicalExamination> PhysicalExaminations { get; set; }
        public DbSet<StressTest> StressTests { get; set; }
        public DbSet<Treatment> Treatments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}