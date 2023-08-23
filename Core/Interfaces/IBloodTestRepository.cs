using Core.Entities;

namespace Core.Interfaces
{
    public interface IBloodTestRepository
    {
        Task<BloodTest> GetBloodTestAsync(int id);
        Task<IReadOnlyList<BloodTest>> GetBloodTestsAsync();
    }
}