using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Repository
{
    public class EchocardiogramRepository : IEchocardiogramRepository
    {
        private readonly ManagementContext _context;

        public EchocardiogramRepository(ManagementContext context)
        {
            _context = context;
        }

        public async Task<Echocardiogram> GetEchocardiogramAsync(int id)
        {
            return await _context.Echocardiograms.FindAsync(id);
        }

        public async Task<IReadOnlyList<Echocardiogram>> GetEchocardiogramsAsync()
        {
            return await _context.Echocardiograms.ToListAsync();
        }
    }
}