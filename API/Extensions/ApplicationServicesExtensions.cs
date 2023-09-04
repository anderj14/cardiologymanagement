using API.Errors;
using Core.Interfaces;
using Infraestructure.Data;
using Infraestructure.Data.Repository;
using Infraestructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services, IConfiguration config
        )
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Conection string
            services.AddDbContext<ManagementContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IBloodTestRepository, BloodTestRepository>();
            services.AddScoped<ICardiacCatheterizationStudyRepository, CardiacCatheterizationStudyRepository>();
            services.AddScoped<IDiagnosticRepository, DiagnosticRepository>();
            services.AddScoped<IDiseaseHistoryRepository, DiseaseHistoryRepository>();
            services.AddScoped<IEchocardiogramRepository, EchocardiogramRepository>();
            services.AddScoped<IElectrocardiogramRepository, ElectrocardiogramRepository>();
            services.AddScoped<IHolterStudyRepository, HolterStudyRepository>();
            services.AddScoped<IMedicalHistoryRepository, MedicalHistoryRepository>();
            services.AddScoped<IPhysicalExaminationRepository, PhysicalExaminationRepository>();
            services.AddScoped<IStressTestRepository, StressTestRepository>();
            services.AddScoped<ITreatmentRepository, TreatmentRepository>();
            ////
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            ////
            // Configure the behavior of the API by configuring 'ApiBehaviorOptions'
            services.Configure<ApiBehaviorOptions>(options =>
            { // An answer factory is established to handle the answers in case of invalid model errors
                options.InvalidModelStateResponseFactory = ActionContext =>
                {
                    var errors = ActionContext.ModelState // Validation errors that have occurred in the request are collected
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse // Which will contain the information of the validation errors of the model.
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            ///
            ////////


            return services;
        }
    }
}