
using Core.Entities;

namespace Core.Specification
{
    public class AppointmentFilterForCountSpecification : BaseSpecification<Appointment>
    {
        public AppointmentFilterForCountSpecification(AppointmentSpecParams appointmentParams)
            : base(x =>
                string.IsNullOrEmpty(appointmentParams.Search) || x.Patient.PatientName.ToLower().Contains(appointmentParams.Search)
                && (!appointmentParams.AppointmentStatusId.HasValue || x.AppointmentStatusId == appointmentParams.AppointmentStatusId))
        {
        }
    }
}