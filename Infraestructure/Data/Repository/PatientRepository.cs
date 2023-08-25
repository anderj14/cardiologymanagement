using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ManagementContext _context;

        public PatientRepository(ManagementContext context)
        {
            _context = context;
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _context.Patients
            .Include(p => p.Appointments)
            .Include(p => p.BloodTests)
            .Include(p => p.CardiacCatheterizationStudies)
            .Include(p => p.Diagnostics)
            .Include(p => p.DiseaseHistories)
            .Include(p => p.Echocardiograms)
            .Include(p => p.Electrocardiograms)
            .Include(p => p.HolterStudies)
            .Include(p => p.MedicalHistories)
            .Include(p => p.PhysicalExaminations)
            .Include(p => p.StressTests)
            .Include(p => p.Treatments)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IReadOnlyList<Patient>> GetPatientsAsync()
        {
            return await _context.Patients
            .Include(p => p.Appointments)
            .Include(p => p.BloodTests)
            .Include(p => p.CardiacCatheterizationStudies)
            .Include(p => p.Diagnostics)
            .Include(p => p.DiseaseHistories)
            .Include(p => p.Echocardiograms)
            .Include(p => p.Electrocardiograms)
            .Include(p => p.HolterStudies)
            .Include(p => p.MedicalHistories)
            .Include(p => p.PhysicalExaminations)
            .Include(p => p.StressTests)
            .Include(p => p.Treatments)
            .ToListAsync();
        }
    }
}