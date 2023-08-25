using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Repository
{
    public class ElectrocardiogramRepository : IElectrocardiogramRepository
    {
        private readonly ManagementContext _context;
        public ElectrocardiogramRepository(ManagementContext context)
        {
            _context = context;
        }

        public async Task<Electrocardiogram> GetElectrocardiogramAsync(int id)
        {
            return await _context.Electrocardiograms.FindAsync(id);
        }

        public async Task<IReadOnlyList<Electrocardiogram>> GetElectrocardiogramsAsync()
        {
            return await _context.Electrocardiograms.ToListAsync();
        }
    }
}