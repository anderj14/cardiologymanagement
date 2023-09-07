
using API.Errors;
using API.Extensions;
using API.Middleware;
using Core.Entities;
using Core.Interfaces;
using Infraestructure.Data;
using Infraestructure.Data.Repository;
using Infraestructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//////////
var app = builder.Build();

// Configure the HTTP request pipeline.

// add the custom exception handling middleware ExceptionMiddleware
app.UseMiddleware<ExceptionMiddleware>();

// Configure the error handling middleware to redirect 
// all HTTP error responses to the path /errors/{0}.
app.UseStatusCodePagesWithReExecute("/errors/{0}");


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Authorization cors
app.UseCors("CorsPolicy");

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
