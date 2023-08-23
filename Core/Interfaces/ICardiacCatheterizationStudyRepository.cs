using Core.Entities;

namespace Core.Interfaces
{
    public interface ICardiacCatheterizationStudyRepository
    {
         Task<CardiacCatheterizationStudy> GetCardiacCatheterizationStudyAsync(int id);
         Task<IReadOnlyList<CardiacCatheterizationStudy>> GetCardiacCatheterizationStudiesAsync();
    }
}