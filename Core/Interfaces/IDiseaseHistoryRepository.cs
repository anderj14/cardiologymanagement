using Core.Entities;

namespace Core.Interfaces
{
    public interface IDiseaseHistoryRepository
    {
         Task<DiseaseHistory> GetDiseaseHistoryAsync(int id);
         Task<IReadOnlyList<DiseaseHistory>> GetDiseaseHistoriesAsync();
    }
}