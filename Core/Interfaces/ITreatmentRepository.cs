using Core.Entities;

namespace Core.Interfaces
{
    public interface ITreatmentRepository
    {
        Task<Treatment> GetTreatmentAsync(int id);
        Task<IReadOnlyList<Treatment>> GetTreatmentsAsync();
    }
}