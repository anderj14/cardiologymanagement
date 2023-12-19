﻿// <auto-generated />
using System;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Data.Migrations
{
    [DbContext(typeof(ManagementContext))]
    partial class ManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("Core.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppointmentStatusId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("PatientId")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentStatusId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Core.Entities.AppointmentStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AppointmentStatusName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AppointmentStatuses");
                });

            modelBuilder.Entity("Core.Entities.BloodTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CholesterolHDL")
                        .HasColumnType("TEXT");

                    b.Property<string>("CholesterolLDL")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Glucose")
                        .HasColumnType("TEXT");

                    b.Property<string>("Hematocrit")
                        .HasColumnType("TEXT");

                    b.Property<string>("Hemoglobin")
                        .HasColumnType("TEXT");

                    b.Property<int>("PatientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Platelets")
                        .HasColumnType("TEXT");

                    b.Property<string>("Triglycerides")
                        .HasColumnType("TEXT");

                    b.Property<string>("WhiteBloodCell")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("BloodTests");
                });

            modelBuilder.Entity("Core.Entities.CardiacCatheterizationStudy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BlockageEachCoronaryArtery")
                        .HasColumnType("TEXT");

                    b.Property<string>("BloodFlowCoronaryArteries")
                        .HasColumnType("TEXT");

                    b.Property<string>("BloodPressureAorta")
                        .HasColumnType("TEXT");

                    b.Property<string>("BloodPressurePulmonaryArteries")
                        .HasColumnType("TEXT");

                    b.Property<string>("ChambersLeftAtrium")
                        .HasColumnType("TEXT");

                    b.Property<string>("ChambersLeftVentricle")
                        .HasColumnType("TEXT");

                    b.Property<string>("ChambersRightAtrium")
                        .HasColumnType("TEXT");

                    b.Property<string>("ChambersRightVentricle")
                        .HasColumnType("TEXT");

                    b.Property<string>("Conclusion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("DescriptionAbnormality")
                        .HasColumnType("TEXT");

                    b.Property<string>("DescriptionComplication")
                        .HasColumnType("TEXT");

                    b.Property<string>("FunctionsCardiacChambers")
                        .HasColumnType("TEXT");

                    b.Property<string>("LeftVentricularEjectionFraction")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumLocationMainCoronary")
                        .HasColumnType("TEXT");

                    b.Property<int>("PatientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PressureGradientValves")
                        .HasColumnType("TEXT");

                    b.Property<string>("StructuralAbnormalities")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("TEXT");

                    b.Property<string>("ValvularInsufficiencyAortic")
                        .HasColumnType("TEXT");

                    b.Property<string>("ValvularInsufficiencyMitral")
                        .HasColumnType("TEXT");

                    b.Property<string>("ValvularInsufficiencyPulmonary")
                        .HasColumnType("TEXT");

                    b.Property<string>("ValvularInsufficiencyTricuspid")
                        .HasColumnType("TEXT");

                    b.Property<string>("VelocityBloodFlow")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("CardiacCatheterizationStudies");
                });

            modelBuilder.Entity("Core.Entities.CardiologySurgery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CardiacCondition")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IsElective")
                        .HasColumnType("TEXT");

                    b.Property<string>("IsEmergency")
                        .HasColumnType("TEXT");

                    b.Property<string>("IsMinimallyInvasive")
                        .HasColumnType("TEXT");

                    b.Property<string>("IsSuccessful")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<string>("OperationRoom")
                        .HasColumnType("TEXT");

                    b.Property<int>("PatientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PostOpDiagnosis")
                        .HasColumnType("TEXT");

                    b.Property<string>("PreOpDiagnosis")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProcedureDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("SurgeryName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("CardiologySurgeries");
                });

            modelBuilder.Entity("Core.Entities.Diagnostic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClassificationCondition")
                        .HasColumnType("TEXT");

                    b.Property<string>("Conclusions")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConditionName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("PatientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RiskAssessment")
                        .HasColumnType("TEXT");

                    b.Property<string>("Severity")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Diagnostics");
                });

            modelBuilder.Entity("Core.Entities.DiseaseHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("PatientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Treatment")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("DiseaseHistories");
                });

            modelBuilder.Entity("Core.Entities.Echocardiogram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BloodFlow")
                        .HasColumnType("TEXT");

                    b.Property<string>("CardiacDimensions")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("EjectionFraction")
                        .HasColumnType("TEXT");

                    b.Property<string>("MovementCardiacWalls")
                        .HasColumnType("TEXT");

                    b.Property<int>("PatientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PulmonaryArterialPressure")
                        .HasColumnType("TEXT");

                    b.Property<string>("ValveFunction")
                        .HasColumnType("TEXT");

                    b.Property<string>("VelocitiesBloodFlows")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Echocardiograms");
                });

            modelBuilder.Entity("Core.Entities.Electrocardiogram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Abnormalities")
                        .HasColumnType("TEXT");

                    b.Property<string>("Artifacts")
                        .HasColumnType("TEXT");

                    b.Property<string>("CharacteristicWaves")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeartRate")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeartRhythm")
                        .HasColumnType("TEXT");

                    b.Property<string>("IntervalsSegments")
                        .HasColumnType("TEXT");

                    b.Property<int>("PatientId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Electrocardiograms");
                });

            modelBuilder.Entity("Core.Entities.HolterStudy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ArrhythmiaEpisodes")
                        .HasColumnType("TEXT");

                    b.Property<string>("AverageHeartRate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Conclusion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaximumHeartRate")
                        .HasColumnType("TEXT");

                    b.Property<int>("PatientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PatientSymptoms")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhysicalActivity")
                        .HasColumnType("TEXT");

                    b.Property<string>("StudyDuration")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeHeartRhythm")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("HolterStudies");
                });

            modelBuilder.Entity("Core.Entities.MedicalHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CardiacProceduresSurgeries")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Diabetes")
                        .HasColumnType("TEXT");

                    b.Property<string>("FamilyDiseases")
                        .HasColumnType("TEXT");

                    b.Property<string>("HighBloodPressure")
                        .HasColumnType("TEXT");

                    b.Property<string>("Hyperlipidemia")
                        .HasColumnType("TEXT");

                    b.Property<string>("Medications")
                        .HasColumnType("TEXT");

                    b.Property<string>("Obesity")
                        .HasColumnType("TEXT");

                    b.Property<int>("PatientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PreviousHeartDisease")
                        .HasColumnType("TEXT");

                    b.Property<string>("Smoking")
                        .HasColumnType("TEXT");

                    b.Property<string>("SystemicDiseases")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("MedicalHistories");
                });

            modelBuilder.Entity("Core.Entities.NoteStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NoteStatusName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("NoteStatuses");
                });

            modelBuilder.Entity("Core.Entities.Notes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("NoteStatusId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NoteStatusId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Core.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("CarnetIdentification")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<long>("Phone")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SocialSecurity")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Core.Entities.PhysicalExamination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AbnormalEcgFindings")
                        .HasColumnType("TEXT");

                    b.Property<string>("Conclusion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExerciseInducedSymptoms")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageEco")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageStress")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaxHeartRate")
                        .HasColumnType("TEXT");

                    b.Property<int>("PatientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PeakPressure")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("PhysicalExaminations");
                });

            modelBuilder.Entity("Core.Entities.StressTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AbnormalEcgFindings")
                        .HasColumnType("TEXT");

                    b.Property<string>("Conclusion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExerciseInducedSymptoms")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageEco")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageStress")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaxHeartRate")
                        .HasColumnType("TEXT");

                    b.Property<int>("PatientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PeakPressure")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("StressTests");
                });

            modelBuilder.Entity("Core.Entities.SurgeryFollowUp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CardiologySurgeryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Complications")
                        .HasColumnType("TEXT");

                    b.Property<string>("FollowUpComplete")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FollowUpDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FollowUpNotes")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CardiologySurgeryId");

                    b.ToTable("SurgeryFollowUps");
                });

            modelBuilder.Entity("Core.Entities.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Dosage")
                        .HasColumnType("TEXT");

                    b.Property<string>("Instructions")
                        .HasColumnType("TEXT");

                    b.Property<string>("Medication")
                        .HasColumnType("TEXT");

                    b.Property<string>("OtherTreatments")
                        .HasColumnType("TEXT");

                    b.Property<int>("PatientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SideEffects")
                        .HasColumnType("TEXT");

                    b.Property<string>("TreatmentMonitoring")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Treatments");
                });

            modelBuilder.Entity("Core.Entities.Appointment", b =>
                {
                    b.HasOne("Core.Entities.AppointmentStatus", "AppointmentStatus")
                        .WithMany()
                        .HasForeignKey("AppointmentStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppointmentStatus");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Core.Entities.BloodTest", b =>
                {
                    b.HasOne("Core.Entities.Patient", "Patient")
                        .WithMany("BloodTests")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Core.Entities.CardiacCatheterizationStudy", b =>
                {
                    b.HasOne("Core.Entities.Patient", "Patient")
                        .WithMany("CardiacCatheterizationStudies")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Core.Entities.CardiologySurgery", b =>
                {
                    b.HasOne("Core.Entities.Patient", "Patient")
                        .WithMany("CardiologySurgery")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Core.Entities.Diagnostic", b =>
                {
                    b.HasOne("Core.Entities.Patient", "Patient")
                        .WithMany("Diagnostics")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Core.Entities.DiseaseHistory", b =>
                {
                    b.HasOne("Core.Entities.Patient", "Patient")
                        .WithMany("DiseaseHistories")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Core.Entities.Echocardiogram", b =>
                {
                    b.HasOne("Core.Entities.Patient", "Patient")
                        .WithMany("Echocardiograms")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Core.Entities.Electrocardiogram", b =>
                {
                    b.HasOne("Core.Entities.Patient", "Patient")
                        .WithMany("Electrocardiograms")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Core.Entities.HolterStudy", b =>
                {
                    b.HasOne("Core.Entities.Patient", "Patient")
                        .WithMany("HolterStudies")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Core.Entities.MedicalHistory", b =>
                {
                    b.HasOne("Core.Entities.Patient", "Patient")
                        .WithMany("MedicalHistories")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Core.Entities.Notes", b =>
                {
                    b.HasOne("Core.Entities.NoteStatus", "NoteStatus")
                        .WithMany()
                        .HasForeignKey("NoteStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NoteStatus");
                });

            modelBuilder.Entity("Core.Entities.PhysicalExamination", b =>
                {
                    b.HasOne("Core.Entities.Patient", "Patient")
                        .WithMany("PhysicalExaminations")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Core.Entities.StressTest", b =>
                {
                    b.HasOne("Core.Entities.Patient", "Patient")
                        .WithMany("StressTests")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Core.Entities.SurgeryFollowUp", b =>
                {
                    b.HasOne("Core.Entities.CardiologySurgery", "CardiologySurgery")
                        .WithMany()
                        .HasForeignKey("CardiologySurgeryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CardiologySurgery");
                });

            modelBuilder.Entity("Core.Entities.Treatment", b =>
                {
                    b.HasOne("Core.Entities.Patient", "Patient")
                        .WithMany("Treatments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Core.Entities.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("BloodTests");

                    b.Navigation("CardiacCatheterizationStudies");

                    b.Navigation("CardiologySurgery");

                    b.Navigation("Diagnostics");

                    b.Navigation("DiseaseHistories");

                    b.Navigation("Echocardiograms");

                    b.Navigation("Electrocardiograms");

                    b.Navigation("HolterStudies");

                    b.Navigation("MedicalHistories");

                    b.Navigation("PhysicalExaminations");

                    b.Navigation("StressTests");

                    b.Navigation("Treatments");
                });
#pragma warning restore 612, 618
        }
    }
}
