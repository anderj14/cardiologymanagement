using Core.Entities;

namespace Core.Interfaces
{
    public interface IMedicalHistoryRepository
    {
         Task<MedicalHistory> GetMedicalHistoryAsync(int id);
         Task<IReadOnlyList<MedicalHistory>> GetMedicalHistoriesAsync();
    }
}