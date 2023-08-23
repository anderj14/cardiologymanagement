using Core.Entities;

namespace Core.Interfaces
{
    public interface IPhysicalExaminationRepository
    {
         Task<PhysicalExamination> GetPhysicalExaminationAsync(int id);
         Task<IReadOnlyList<PhysicalExamination>> GetPhysicalExaminationsAsync();
    }
}