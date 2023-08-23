using Core.Entities;

namespace Core.Interfaces
{
    public interface IStressTestRepository
    {
         Task<StressTest> GetStressTestAsync(int id);
         Task<IReadOnlyList<StressTest>> GetStressTestsAsync();
    }
}