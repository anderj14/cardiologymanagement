namespace Core.Dtos
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string CarnetIdentification { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public long NoMedicare { get; set; }

        public ICollection<AppointmentDto> Appointments { get; set; }
        public ICollection<DiseaseHistoryDto> DiseaseHistories { get; set; }
        public ICollection<MedicalHistoryDto> MedicalHistories { get; set; }
        public ICollection<PhysicalExaminationDto> PhysicalExaminations { get; set; } 
        public ICollection<ElectrocardiogramDto> Electrocardiograms { get; set; }
        public ICollection<EchocardiogramDto> Echocardiograms { get; set; }
        public ICollection<StressTestDto> StressTests { get; set; } 
        public ICollection<HolterStudyDto> HolterStudies { get; set; }
        public ICollection<CardiacCatheterizationStudyDto> CardiacCatheterizationStudies { get; set; }
        public ICollection<BloodTestDto> BloodTests { get; set; }         
        public ICollection<DiagnosticDto> Diagnostics { get; set; }
        public ICollection<TreatmentDto> Treatments { get; set; }

    }
}