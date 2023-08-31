using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specification
{
    public class PatientWithAllSpecification : BaseSpecification<Patient>
    {
        public PatientWithAllSpecification()
        {
            AddInclude(x => x.Appointments);
            AddInclude(x => x.BloodTests);
            AddInclude(x => x.CardiacCatheterizationStudies);
            AddInclude(x => x.Diagnostics);
            AddInclude(x => x.DiseaseHistories);
            AddInclude(x => x.Echocardiograms);
            AddInclude(x => x.Electrocardiograms);
            AddInclude(x => x.HolterStudies);
            AddInclude(x => x.MedicalHistories);
            AddInclude(x => x.PhysicalExaminations);
            AddInclude(x => x.StressTests);
            AddInclude(x => x.Treatments);
        }

        public PatientWithAllSpecification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(x => x.Appointments);
            AddInclude(x => x.BloodTests);
            AddInclude(x => x.CardiacCatheterizationStudies);
            AddInclude(x => x.Diagnostics);
            AddInclude(x => x.DiseaseHistories);
            AddInclude(x => x.Echocardiograms);
            AddInclude(x => x.Electrocardiograms);
            AddInclude(x => x.HolterStudies);
            AddInclude(x => x.MedicalHistories);
            AddInclude(x => x.PhysicalExaminations);
            AddInclude(x => x.StressTests);
            AddInclude(x => x.Treatments);
        }
    }
}