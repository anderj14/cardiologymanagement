using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Repository
{
    public class StressTestRepository : IStressTestRepository
    {
        private readonly ManagementContext _context;

        public StressTestRepository(ManagementContext context)
        {
            _context = context;
        }

        public async Task<StressTest> GetStressTestAsync(int id)
        {
            return await _context.StressTests.FindAsync(id);
        }

        public async Task<IReadOnlyList<StressTest>> GetStressTestsAsync()
        {
            return await _context.StressTests.ToListAsync();
        }
    }
}