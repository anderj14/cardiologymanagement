using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Repository
{
    public class TreatmentRepository : ITreatmentRepository
    {
        private readonly ManagementContext _context;

        public TreatmentRepository(ManagementContext context)
        {
            _context = context;
        }
        public async Task<Treatment> GetTreatmentAsync(int id)
        {
            return await _context.Treatments.FindAsync(id);
        }

        public async Task<IReadOnlyList<Treatment>> GetTreatmentsAsync()
        {
            return await _context.Treatments.ToListAsync();
        }
    }
}