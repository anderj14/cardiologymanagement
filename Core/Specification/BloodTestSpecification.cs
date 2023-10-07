
using Core.Entities;

namespace Core.Specification
{
    public class BloodTestSpecification : BaseSpecification<BloodTest>
    {
        public BloodTestSpecification(int patientId, int bloodTestId)
            : base(bt => bt.PatientId == patientId && bt.Id == bloodTestId)
        {
            AddInclude(bt => bt.Patient);
        }

        public BloodTestSpecification(int patientId) 
        : base(bt => bt.PatientId == patientId)
        {
            AddInclude(bt => bt.Patient);
        }


    }
}