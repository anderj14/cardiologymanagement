using Core.Entities;

namespace Core.Interfaces
{
    public interface IPatientRepository
    {
         Task<Patient> GetPatientByIdAsync(int id);
         Task<IReadOnlyList<Patient>> GetPatientsAsync();
    }
}