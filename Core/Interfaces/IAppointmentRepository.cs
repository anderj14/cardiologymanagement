using Core.Entities;

namespace Core.Interfaces
{
    public interface IAppointmentRepository
    {
         Task<Appointment> GetAppointmentByIdAsync(int id);
         Task<IReadOnlyList<Appointment>> GetAppointmentsAsync();
         Task<IReadOnlyList<Appointment>> GetAppointmentsByPatientIdAsync();
         Task<Appointment> GetAppointmentByPatientIdAsync();
    }
}