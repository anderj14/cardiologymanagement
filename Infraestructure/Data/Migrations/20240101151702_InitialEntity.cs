using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AppointmentStatusName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoteStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NoteStatusName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PatientName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    CarnetIdentification = table.Column<string>(type: "TEXT", nullable: false),
                    DOB = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<long>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    SocialSecurity = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Time = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    NoteStatusId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_NoteStatuses_NoteStatusId",
                        column: x => x.NoteStatusId,
                        principalTable: "NoteStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Time = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    AppointmentStatusId = table.Column<int>(type: "INTEGER", nullable: false),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AppointmentStatuses_AppointmentStatusId",
                        column: x => x.AppointmentStatusId,
                        principalTable: "AppointmentStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BloodTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Hemoglobin = table.Column<string>(type: "TEXT", nullable: true),
                    Hematocrit = table.Column<string>(type: "TEXT", nullable: true),
                    WhiteBloodCell = table.Column<string>(type: "TEXT", nullable: true),
                    Platelets = table.Column<string>(type: "TEXT", nullable: true),
                    Glucose = table.Column<string>(type: "TEXT", nullable: true),
                    CholesterolHDL = table.Column<string>(type: "TEXT", nullable: true),
                    CholesterolLDL = table.Column<string>(type: "TEXT", nullable: true),
                    Triglycerides = table.Column<string>(type: "TEXT", nullable: true),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodTests_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardiacCatheterizationStudies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Time = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    NumLocationMainCoronary = table.Column<string>(type: "TEXT", nullable: true),
                    BlockageEachCoronaryArtery = table.Column<string>(type: "TEXT", nullable: true),
                    DescriptionAbnormality = table.Column<string>(type: "TEXT", nullable: true),
                    BloodPressureAorta = table.Column<string>(type: "TEXT", nullable: true),
                    ChambersLeftAtrium = table.Column<string>(type: "TEXT", nullable: true),
                    ChambersLeftVentricle = table.Column<string>(type: "TEXT", nullable: true),
                    ChambersRightAtrium = table.Column<string>(type: "TEXT", nullable: true),
                    ChambersRightVentricle = table.Column<string>(type: "TEXT", nullable: true),
                    BloodFlowCoronaryArteries = table.Column<string>(type: "TEXT", nullable: true),
                    VelocityBloodFlow = table.Column<string>(type: "TEXT", nullable: true),
                    LeftVentricularEjectionFraction = table.Column<string>(type: "TEXT", nullable: true),
                    BloodPressurePulmonaryArteries = table.Column<string>(type: "TEXT", nullable: true),
                    ValvularInsufficiencyAortic = table.Column<string>(type: "TEXT", nullable: true),
                    ValvularInsufficiencyMitral = table.Column<string>(type: "TEXT", nullable: true),
                    ValvularInsufficiencyPulmonary = table.Column<string>(type: "TEXT", nullable: true),
                    ValvularInsufficiencyTricuspid = table.Column<string>(type: "TEXT", nullable: true),
                    PressureGradientValves = table.Column<string>(type: "TEXT", nullable: true),
                    StructuralAbnormalities = table.Column<string>(type: "TEXT", nullable: true),
                    FunctionsCardiacChambers = table.Column<string>(type: "TEXT", nullable: true),
                    DescriptionComplication = table.Column<string>(type: "TEXT", nullable: true),
                    Conclusion = table.Column<string>(type: "TEXT", nullable: true),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardiacCatheterizationStudies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardiacCatheterizationStudies_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardiologySurgeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SurgeryName = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Time = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    ProcedureDescription = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    IsEmergency = table.Column<string>(type: "TEXT", nullable: true),
                    IsElective = table.Column<string>(type: "TEXT", nullable: true),
                    OperationRoom = table.Column<string>(type: "TEXT", nullable: true),
                    PreOpDiagnosis = table.Column<string>(type: "TEXT", nullable: true),
                    PostOpDiagnosis = table.Column<string>(type: "TEXT", nullable: true),
                    IsSuccessful = table.Column<string>(type: "TEXT", nullable: true),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    CardiacCondition = table.Column<string>(type: "TEXT", nullable: true),
                    IsMinimallyInvasive = table.Column<string>(type: "TEXT", nullable: true),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardiologySurgeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardiologySurgeries_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diagnostics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ConditionName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ClassificationCondition = table.Column<string>(type: "TEXT", nullable: true),
                    Severity = table.Column<string>(type: "TEXT", nullable: true),
                    RiskAssessment = table.Column<string>(type: "TEXT", nullable: true),
                    Conclusions = table.Column<string>(type: "TEXT", nullable: true),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnostics_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiseaseHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Treatment = table.Column<string>(type: "TEXT", nullable: true),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiseaseHistories_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Echocardiograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CardiacDimensions = table.Column<string>(type: "TEXT", nullable: true),
                    EjectionFraction = table.Column<string>(type: "TEXT", nullable: true),
                    ValveFunction = table.Column<string>(type: "TEXT", nullable: true),
                    VelocitiesBloodFlows = table.Column<string>(type: "TEXT", nullable: true),
                    MovementCardiacWalls = table.Column<string>(type: "TEXT", nullable: true),
                    PulmonaryArterialPressure = table.Column<string>(type: "TEXT", nullable: true),
                    BloodFlow = table.Column<string>(type: "TEXT", nullable: true),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Echocardiograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Echocardiograms_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Electrocardiograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HeartRhythm = table.Column<string>(type: "TEXT", nullable: true),
                    IntervalsSegments = table.Column<string>(type: "TEXT", nullable: true),
                    CharacteristicWaves = table.Column<string>(type: "TEXT", nullable: true),
                    HeartRate = table.Column<string>(type: "TEXT", nullable: true),
                    Abnormalities = table.Column<string>(type: "TEXT", nullable: true),
                    Artifacts = table.Column<string>(type: "TEXT", nullable: true),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electrocardiograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Electrocardiograms_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HolterStudies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Time = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    StudyDuration = table.Column<string>(type: "TEXT", nullable: true),
                    AverageHeartRate = table.Column<string>(type: "TEXT", nullable: true),
                    MaximumHeartRate = table.Column<string>(type: "TEXT", nullable: true),
                    TypeHeartRhythm = table.Column<string>(type: "TEXT", nullable: true),
                    ArrhythmiaEpisodes = table.Column<string>(type: "TEXT", nullable: true),
                    PhysicalActivity = table.Column<string>(type: "TEXT", nullable: true),
                    PatientSymptoms = table.Column<string>(type: "TEXT", nullable: true),
                    Conclusion = table.Column<string>(type: "TEXT", nullable: true),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolterStudies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HolterStudies_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PreviousHeartDisease = table.Column<string>(type: "TEXT", nullable: true),
                    HighBloodPressure = table.Column<string>(type: "TEXT", nullable: true),
                    Diabetes = table.Column<string>(type: "TEXT", nullable: true),
                    Hyperlipidemia = table.Column<string>(type: "TEXT", nullable: true),
                    Obesity = table.Column<string>(type: "TEXT", nullable: true),
                    Smoking = table.Column<string>(type: "TEXT", nullable: true),
                    CardiacProceduresSurgeries = table.Column<string>(type: "TEXT", nullable: true),
                    SystemicDiseases = table.Column<string>(type: "TEXT", nullable: true),
                    Medications = table.Column<string>(type: "TEXT", nullable: true),
                    FamilyDiseases = table.Column<string>(type: "TEXT", nullable: true),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalHistories_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalExaminations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Time = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Duration = table.Column<string>(type: "TEXT", nullable: true),
                    MaxHeartRate = table.Column<string>(type: "TEXT", nullable: true),
                    PeakPressure = table.Column<string>(type: "TEXT", nullable: true),
                    ExerciseInducedSymptoms = table.Column<string>(type: "TEXT", nullable: true),
                    AbnormalEcgFindings = table.Column<string>(type: "TEXT", nullable: true),
                    ImageEco = table.Column<string>(type: "TEXT", nullable: true),
                    ImageStress = table.Column<string>(type: "TEXT", nullable: true),
                    Conclusion = table.Column<string>(type: "TEXT", nullable: true),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalExaminations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalExaminations_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StressTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Time = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Duration = table.Column<string>(type: "TEXT", nullable: true),
                    MaxHeartRate = table.Column<string>(type: "TEXT", nullable: true),
                    PeakPressure = table.Column<string>(type: "TEXT", nullable: true),
                    ExerciseInducedSymptoms = table.Column<string>(type: "TEXT", nullable: true),
                    AbnormalEcgFindings = table.Column<string>(type: "TEXT", nullable: true),
                    ImageEco = table.Column<string>(type: "TEXT", nullable: true),
                    ImageStress = table.Column<string>(type: "TEXT", nullable: true),
                    Conclusion = table.Column<string>(type: "TEXT", nullable: true),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StressTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StressTests_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Medication = table.Column<string>(type: "TEXT", nullable: true),
                    Dosage = table.Column<string>(type: "TEXT", nullable: true),
                    Instructions = table.Column<string>(type: "TEXT", nullable: true),
                    OtherTreatments = table.Column<string>(type: "TEXT", nullable: true),
                    SideEffects = table.Column<string>(type: "TEXT", nullable: true),
                    TreatmentMonitoring = table.Column<string>(type: "TEXT", nullable: true),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurgeryFollowUps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FollowUpDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FollowUpNotes = table.Column<string>(type: "TEXT", nullable: true),
                    Complications = table.Column<string>(type: "TEXT", nullable: true),
                    FollowUpComplete = table.Column<string>(type: "TEXT", nullable: true),
                    CardiologySurgeryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurgeryFollowUps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurgeryFollowUps_CardiologySurgeries_CardiologySurgeryId",
                        column: x => x.CardiologySurgeryId,
                        principalTable: "CardiologySurgeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentStatusId",
                table: "Appointments",
                column: "AppointmentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodTests_PatientId",
                table: "BloodTests",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_CardiacCatheterizationStudies_PatientId",
                table: "CardiacCatheterizationStudies",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_CardiologySurgeries_PatientId",
                table: "CardiologySurgeries",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostics_PatientId",
                table: "Diagnostics",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseHistories_PatientId",
                table: "DiseaseHistories",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Echocardiograms_PatientId",
                table: "Echocardiograms",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Electrocardiograms_PatientId",
                table: "Electrocardiograms",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_HolterStudies_PatientId",
                table: "HolterStudies",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_PatientId",
                table: "MedicalHistories",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_NoteStatusId",
                table: "Notes",
                column: "NoteStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalExaminations_PatientId",
                table: "PhysicalExaminations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_StressTests_PatientId",
                table: "StressTests",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_SurgeryFollowUps_CardiologySurgeryId",
                table: "SurgeryFollowUps",
                column: "CardiologySurgeryId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_PatientId",
                table: "Treatments",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "BloodTests");

            migrationBuilder.DropTable(
                name: "CardiacCatheterizationStudies");

            migrationBuilder.DropTable(
                name: "Diagnostics");

            migrationBuilder.DropTable(
                name: "DiseaseHistories");

            migrationBuilder.DropTable(
                name: "Echocardiograms");

            migrationBuilder.DropTable(
                name: "Electrocardiograms");

            migrationBuilder.DropTable(
                name: "HolterStudies");

            migrationBuilder.DropTable(
                name: "MedicalHistories");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "PhysicalExaminations");

            migrationBuilder.DropTable(
                name: "StressTests");

            migrationBuilder.DropTable(
                name: "SurgeryFollowUps");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "AppointmentStatuses");

            migrationBuilder.DropTable(
                name: "NoteStatuses");

            migrationBuilder.DropTable(
                name: "CardiologySurgeries");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
