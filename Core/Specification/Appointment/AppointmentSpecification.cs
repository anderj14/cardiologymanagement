using Core.Entities;

namespace Core.Specification
{
    public class AppointmentSpecification : BaseSpecification<Appointment>
    {
        public AppointmentSpecification(AppointmentSpecParams appointmentParams)
            : base(x =>
            string.IsNullOrEmpty(appointmentParams.Search) || x.Patient.PatientName.ToLower().Contains(appointmentParams.Search))
        {
            AddInclude(a => a.Patient);

            ApplyPaging(appointmentParams.PageSize * (appointmentParams.PageIndex - 1),
            appointmentParams.PageSize);

            if (!string.IsNullOrEmpty(appointmentParams.Sort))
            {
                switch (appointmentParams.Sort)
                {
                    case "dateAsc":
                        AddOrderBy(a => a.Date);
                        break;
                    case "dateDesc":
                        AddOrderByDescending(a => a.Date);
                        break;
                    case "timeAsc":
                        AddOrderBy(a => a.Time);
                        break;
                    case "timeDesc":
                        AddOrderByDescending(a => a.Time);
                        break;

                    default:
                        AddOrderBy(n => n.Patient.PatientName);
                        break;
                }
            }
        }

        public AppointmentSpecification(int patientId, int appointmentId)
            : base(a => a.PatientId == patientId && a.Id == appointmentId)
        {
            AddInclude(a => a.Patient);
        }


        public AppointmentSpecification(int patientId)
            : base(a => a.PatientId == patientId)
        {
            AddInclude(a => a.Patient);
        }
    }
}