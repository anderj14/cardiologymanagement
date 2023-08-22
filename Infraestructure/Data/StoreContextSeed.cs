using System.Text.Json;
using Core.Entities;

namespace Infraestructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(ManagementContext context)
        {
            if(!context.Patients.Any()){
                var patientsData = File.ReadAllText("../Infraestructure/Data/SeedData/patient.json");
                var patient = JsonSerializer.Deserialize<List<Patient>>(patientsData);
                context.Patients.AddRange(patient);
            }
            if(!context.Appointments.Any()){
                var appointmentsData = File.ReadAllText("../Infraestructure/Data/SeedData/appointment.json");
                var appointments = JsonSerializer.Deserialize<List<Appointment>>(appointmentsData);
                context.Appointments.AddRange(appointments);
            }
            if(!context.BloodTests.Any()){
                var bloodTestData = File.ReadAllText("../Infraestructure/Data/SeedData/bloodtest.json");
                var bloodTest = JsonSerializer.Deserialize<List<BloodTest>>(bloodTestData);
                context.BloodTests.AddRange(bloodTest);
            }
            if(!context.CardiacCatheterizationStudies.Any()){
                var cardiacCatheterizationStudiesData = File.ReadAllText("../Infraestructure/Data/SeedData/cardiaccatheterizationstudy.json");
                var cardiacCatheterizationStudies = JsonSerializer.Deserialize<List<CardiacCatheterizationStudy>>(cardiacCatheterizationStudiesData);
                context.CardiacCatheterizationStudies.AddRange(cardiacCatheterizationStudies);
            }
            if(!context.Diagnostics.Any()){
                var diagnosticsData = File.ReadAllText("../Infraestructure/Data/SeedData/diagnostic.json");
                var diagnostics = JsonSerializer.Deserialize<List<Diagnostic>>(diagnosticsData);
                context.Diagnostics.AddRange(diagnostics);
            }
            if(!context.DiseaseHistories.Any()){
                var diseaseHistoriesData = File.ReadAllText("../Infraestructure/Data/SeedData/diseasehistory.json");
                var diseaseHistory = JsonSerializer.Deserialize<List<DiseaseHistory>>(diseaseHistoriesData);
                context.DiseaseHistories.AddRange(diseaseHistory);
            }
            if(!context.Echocardiograms.Any()){
                var echocardiogramsData = File.ReadAllText("../Infraestructure/Data/SeedData/echocardiogram.json");
                var echocardiograms = JsonSerializer.Deserialize<List<Echocardiogram>>(echocardiogramsData);
                context.Echocardiograms.AddRange(echocardiograms);
            }
            if(!context.Electrocardiograms.Any()){
                var electrocardiogramsData = File.ReadAllText("../Infraestructure/Data/SeedData/electrocardiogram.json");
                var electrocardiograms = JsonSerializer.Deserialize<List<Electrocardiogram>>(electrocardiogramsData);
                context.Electrocardiograms.AddRange(electrocardiograms);
            }
            if(!context.HolterStudies.Any()){
                var holterstudiesData = File.ReadAllText("../Infraestructure/Data/SeedData/holterstudy.json");
                var holterstudies = JsonSerializer.Deserialize<List<HolterStudy>>(holterstudiesData);
                context.HolterStudies.AddRange(holterstudies);
            }
            if(!context.MedicalHistories.Any()){
                var medicalHistoriesData = File.ReadAllText("../Infraestructure/Data/SeedData/medicalhistory.json");
                var medicalHistory = JsonSerializer.Deserialize<List<MedicalHistory>>(medicalHistoriesData);
                context.MedicalHistories.AddRange(medicalHistory);
            }
            if(!context.PhysicalExaminations.Any()){
                var physicalexaminationsData = File.ReadAllText("../Infraestructure/Data/SeedData/physicalexamination.json");
                var physicalexamination = JsonSerializer.Deserialize<List<PhysicalExamination>>(physicalexaminationsData);
                context.PhysicalExaminations.AddRange(physicalexamination);
            }
            if(!context.StressTests.Any()){
                var stressTestsData = File.ReadAllText("../Infraestructure/Data/SeedData/stresstest.json");
                var stressTest = JsonSerializer.Deserialize<List<StressTest>>(stressTestsData);
                context.StressTests.AddRange(stressTest);
            }
            if(!context.Treatments.Any()){
                var treatmentsData = File.ReadAllText("../Infraestructure/Data/SeedData/treatment.json");
                var treatments = JsonSerializer.Deserialize<List<Treatment>>(treatmentsData);
                context.Treatments.AddRange(treatments);
            }
            
            if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}