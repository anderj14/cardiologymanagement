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
        public DbSet<AppointmentStatus> AppointmentStatuses { get; set; }
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
        public DbSet<CardiologySurgery> CardiologySurgeries { get; set; }
        public DbSet<SurgeryFollowUp> SurgeryFollowUps { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<NoteStatus> NoteStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // configures the conversion of properties from type decimal to double.
            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                // This loop iterates through all entities.
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    // All decimal type properties are obtained for the current entity.
                    var properties = entityType.ClrType.GetProperties()
                    .Where(p => p.PropertyType == typeof(decimal));
                    // This loop iterates through the decimal type properties found in the entity.
                    foreach (var property in properties)
                    {
                        // Configure the conversion of the identified decimal property to double
                        modelBuilder.Entity(entityType.Name).Property(property.Name)
                        .HasConversion<double>();
                    }
                }
            }
        }
    }
}