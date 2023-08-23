using Core.Dtos;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IPatientRepository
    {
        // Task<PatientDto> GetPatientByIdAsync(int id);
        // Task<IReadOnlyList<PatientDto>> GetPatientsAsync();

        Task<Patient> GetPatientByIdAsync(int id);
        Task<IReadOnlyList<Patient>> GetPatientsAsync();
    }
}