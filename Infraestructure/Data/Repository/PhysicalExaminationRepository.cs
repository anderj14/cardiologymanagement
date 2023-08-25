using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Repository
{
    public class PhysicalExaminationRepository : IPhysicalExaminationRepository
    {
        private readonly ManagementContext _context;

        public PhysicalExaminationRepository(ManagementContext context)
        {
            _context = context;
        }
        public async Task<PhysicalExamination> GetPhysicalExaminationAsync(int id)
        {
            return await _context.PhysicalExaminations.FindAsync(id);
        }

        public async Task<IReadOnlyList<PhysicalExamination>> GetPhysicalExaminationsAsync()
        {
            return await _context.PhysicalExaminations.ToListAsync();
        }
    }
}