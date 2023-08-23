using Core.Entities;

namespace Core.Interfaces
{
    public interface IElectrocardiogramRepository
    {
        Task<Electrocardiogram> GetElectrocardiogramAsync(int id);
        Task<IReadOnlyList<Electrocardiogram>> GetElectrocardiogramsAsync();
    }
}