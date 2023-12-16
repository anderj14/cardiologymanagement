using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specification
{
    public class AppointmentFilterForCountSpecification : BaseSpecification<Appointment>
    {
        public AppointmentFilterForCountSpecification(AppointmentSpecParams appointmentParams)
            : base(x =>
                string.IsNullOrEmpty(appointmentParams.Search) ||
                x.Patient.PatientName.ToLower().Contains(appointmentParams.Search))
        {
        }
    }
}