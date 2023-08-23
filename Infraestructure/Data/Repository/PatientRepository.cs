using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ManagementContext _context;
        // private readonly IMapper _mapper;

        public PatientRepository(ManagementContext context)
        {
            _context = context;
        }
        // public PatientRepository(ManagementContext context, IMapper mapper)
        // {
        //     _context = context;
        //     _mapper = mapper;
        // }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _context.Patients
            .FindAsync(id);
        }

        // public async Task<PatientDto> GetPatientByIdAsync(int id)
        // {
        //     var patient = await _context.Patients
        //     .Include(p => p.Appointments)
        //     .FirstOrDefaultAsync(p => p.Id == id);

        //     if (patient == null)
        //     {
        //         // Manejar el caso donde no se encuentra el paciente
        //         return null;
        //     }
        //     return _mapper.Map<PatientDto>(patient);
        // }

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
        // public async Task<IReadOnlyList<PatientDto>> GetPatientsAsync()
        // {
        //     var patients = await _context.Patients
        //     .Include(p => p.Appointments)
        //     .ToListAsync();

        //     return _mapper.Map<List<PatientDto>>(patients);
        // }
    }
}