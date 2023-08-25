using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Repository
{
    public class MedicalHistoryRepository : IMedicalHistoryRepository
    {
        private readonly ManagementContext _context;

        public MedicalHistoryRepository(ManagementContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<MedicalHistory>> GetMedicalHistoriesAsync()
        {
            return await _context.MedicalHistories.ToListAsync();
        }

        public async Task<MedicalHistory> GetMedicalHistoryAsync(int id)
        {
            return await _context.MedicalHistories.FindAsync(id);
        }
    }
}