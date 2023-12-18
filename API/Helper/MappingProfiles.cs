using AutoMapper;
using Core.Dtos;
using Core.Entities;

namespace API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Patient, PatientDto>()
            .ForMember(p => p.Appointments, o => o.MapFrom(s => s.Appointments))
            .ForMember(p => p.BloodTests, o => o.MapFrom(s => s.BloodTests))
            .ForMember(p => p.CardiacCatheterizationStudies, o => o.MapFrom(s => s.CardiacCatheterizationStudies))
            .ForMember(p => p.Diagnostics, o => o.MapFrom(s => s.Diagnostics))
            .ForMember(p => p.DiseaseHistories, o => o.MapFrom(s => s.DiseaseHistories))
            .ForMember(p => p.Echocardiograms, o => o.MapFrom(s => s.Echocardiograms))
            .ForMember(p => p.Electrocardiograms, o => o.MapFrom(s => s.Electrocardiograms))
            .ForMember(p => p.HolterStudies, o => o.MapFrom(s => s.HolterStudies))
            .ForMember(p => p.MedicalHistories, o => o.MapFrom(s => s.MedicalHistories))
            .ForMember(p => p.PhysicalExaminations, o => o.MapFrom(s => s.PhysicalExaminations))
            .ForMember(p => p.StressTests, o => o.MapFrom(s => s.StressTests))
            .ForMember(p => p.Treatments, o => o.MapFrom(s => s.Treatments));

            // CreateMap<Model, ModelDto>()
            // .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.BrandName));


            CreateMap<Appointment, AppointmentDto>()
            .ForMember(d => d.Patient, o => o.MapFrom(s => s.Patient.PatientName));
            CreateMap<BloodTest, BloodTestDto>();
            CreateMap<CardiacCatheterizationStudy, CardiacCatheterizationStudyDto>();
            CreateMap<Diagnostic, DiagnosticDto>();
            CreateMap<DiseaseHistory, DiseaseHistoryDto>();
            CreateMap<Echocardiogram, EchocardiogramDto>();
            CreateMap<Electrocardiogram, ElectrocardiogramDto>();
            CreateMap<HolterStudy, HolterStudyDto>();
            CreateMap<MedicalHistory, MedicalHistoryDto>();
            CreateMap<PhysicalExamination, PhysicalExaminationDto>();
            CreateMap<StressTest, StressTestDto>();
            CreateMap<Treatment, TreatmentDto>();
        }
    }
}