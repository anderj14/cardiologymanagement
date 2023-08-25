using Core.Entities;
using Core.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository
{
    public class HolterStudyRepository : IHolterStudyRepository
    {
        private readonly ManagementContext _context;

        public HolterStudyRepository(ManagementContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<HolterStudy>> GetHolterStudiesAsync()
        {
            return await _context.HolterStudies.ToListAsync();
        }

        public async Task<HolterStudy> GetHolterStudyAsync(int id)
        {
            return await _context.HolterStudies.FindAsync(id);
        }
    }
}