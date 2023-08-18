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
            return await _context.Patients.FindAsync(id);
        }

        public async Task<IReadOnlyList<Patient>> GetPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }
    }
}