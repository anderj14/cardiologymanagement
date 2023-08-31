using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specification
{
    public class BloodTestSpecification : BaseSpecification<BloodTest>
    {
        public BloodTestSpecification(int patientId, int bloodTestId)
            : base(bt => bt.PatientId == patientId && bt.Id == bloodTestId)
        {
            AddInclude(bt => bt.PatientId);
        }

        public BloodTestSpecification(int patientId) : base(bt => bt.PatientId == patientId)
        {
            AddInclude(bt => bt.PatientId);
        }


    }
}