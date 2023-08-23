using Core.Entities;

namespace Core.Interfaces
{
    public interface IHolterStudyRepository
    {
         Task<HolterStudy> GetHolterStudyAsync(int id);
         Task<IReadOnlyList<HolterStudy>> GetHolterStudiesAsync();
    }
}