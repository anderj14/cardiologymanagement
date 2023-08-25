
using Core.Entities;
using Core.Interfaces;
using Infraestructure.Data;
using Infraestructure.Data.Repository;
using Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<ManagementContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// builder.Services.AddControllers().AddJsonOptions(options =>
// {
//     options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
// });

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IBloodTestRepository, BloodTestRepository>();
builder.Services.AddScoped<ICardiacCatheterizationStudyRepository, CardiacCatheterizationStudyRepository>();
builder.Services.AddScoped<IDiagnosticRepository, DiagnosticRepository>();
builder.Services.AddScoped<IDiseaseHistoryRepository, DiseaseHistoryRepository>();
builder.Services.AddScoped<IEchocardiogramRepository, EchocardiogramRepository>();
builder.Services.AddScoped<IElectrocardiogramRepository, ElectrocardiogramRepository>();
builder.Services.AddScoped<IHolterStudyRepository, HolterStudyRepository>();
builder.Services.AddScoped<IMedicalHistoryRepository, MedicalHistoryRepository>();
builder.Services.AddScoped<IPhysicalExaminationRepository, PhysicalExaminationRepository>();
builder.Services.AddScoped<IStressTestRepository, StressTestRepository>();
builder.Services.AddScoped<ITreatmentRepository, TreatmentRepository>();
////////

//////////
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<ManagementContext>();
var logger = services.GetRequiredService<ILogger<Program>>();

try
{
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error ocurring during migration");
}

app.Run();
