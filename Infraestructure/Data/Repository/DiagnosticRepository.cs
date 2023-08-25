using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Repository
{
    public class DiagnosticRepository : IDiagnosticRepository
    {
        private readonly ManagementContext _context;

        public DiagnosticRepository(ManagementContext context)
        {
            _context = context;
        }

        public async Task<Diagnostic> GetDiagnosticAsync(int id)
        {
            return await _context.Diagnostics.FindAsync(id);
        }

        public async Task<IReadOnlyList<Diagnostic>> GetDiagnosticsAsync()
        {
            return await _context.Diagnostics.ToListAsync();
        }
    }
}