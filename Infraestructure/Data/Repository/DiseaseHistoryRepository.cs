using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Repository
{
    public class DiseaseHistoryRepository : IDiseaseHistoryRepository
    {
        private readonly ManagementContext _context;

        public DiseaseHistoryRepository(ManagementContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<DiseaseHistory>> GetDiseaseHistoriesAsync()
        {
            return await _context.DiseaseHistories.ToListAsync();
        }

        public async Task<DiseaseHistory> GetDiseaseHistoryAsync(int id)
        {
            return await _context.DiseaseHistories.FindAsync(id);
        }
    }
}