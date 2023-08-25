using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Repository
{
    public class BloodTestRepository : IBloodTestRepository
    {
        private readonly ManagementContext _context;
        public BloodTestRepository(ManagementContext context)
        {
            _context = context;
        }

        public async Task<BloodTest> GetBloodTestAsync(int id)
        {
            return await _context.BloodTests.FindAsync(id);
        }

        public async Task<IReadOnlyList<BloodTest>> GetBloodTestsAsync()
        {
            return await _context.BloodTests.ToListAsync();
        }
    }
}