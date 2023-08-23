using Core.Entities;

namespace Core.Interfaces
{
    public interface IDiagnosticRepository
    {
         Task<Diagnostic> GetDiagnosticAsync(int id);
         Task<IReadOnlyList<Diagnostic>> GetDiagnosticsAsync();
    }
}