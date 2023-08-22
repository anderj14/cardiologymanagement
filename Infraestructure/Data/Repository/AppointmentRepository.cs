using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ManagementContext _context;

        public AppointmentRepository(ManagementContext context)
        {
            _context = context;
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            return await _context.Appointments
            .FindAsync(id);
        }

        public async Task<IReadOnlyList<Appointment>> GetAppointmentsAsync()
        {
            return await _context.Appointments
            .ToListAsync();
        }

        public Task<Appointment> GetAppointmentByPatientIdAsync()
        {
            throw new NotImplementedException();
        }
        public Task<IReadOnlyList<Appointment>> GetAppointmentsByPatientIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}