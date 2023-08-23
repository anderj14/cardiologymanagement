using Core.Entities;

namespace Core.Interfaces
{
    public interface IEchocardiogramRepository
    {
         Task<IReadOnlyList<Echocardiogram>> GetEchocardiogramsAsync();
         Task<Echocardiogram> GetEchocardiogramAsync(int id);
    }
}