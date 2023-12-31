using API.Extensions;
using API.Middleware;
using Core.Entities.Identity;
using Infraestructure.Data;
using Infraestructure.Identity;
using Microsoft.AspNetCore.Identity;


// using Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityService(builder.Configuration);
builder.Services.AddSwaggerDocumentation();

//////////
var app = builder.Build();

// Configure the HTTP request pipeline.

// add the custom exception handling middleware ExceptionMiddleware
app.UseMiddleware<ExceptionMiddleware>();

// Configure the error handling middleware to redirect 
// all HTTP error responses to the path /errors/{0}.
app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.userSwaggerDocumentation();


app.UseHttpsRedirection();

// Authorization cors
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


using var scope = app.Services.CreateScope();


var services = scope.ServiceProvider;
var context = services.GetRequiredService<ManagementContext>();
var logger = services.GetRequiredService<ILogger<Program>>();

try
{
    await context.Database.MigrateAsync();
    // await identityContext.Database.MigrateAsync(); // Identity
    await StoreContextSeed.SeedAsync(context);

    var userManager = services.GetRequiredService<UserManager<AppUser>>(); // Identity
    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
    var identityContext = services.GetRequiredService<AppIdentityDbContext>();
    await identityContext.Database.MigrateAsync();
    await AppIdentityDbContextSeed.SeedUsersAsync(userManager, roleManager);

    // await AppIdentityDbContextSeed.SeedUsersAsync(userManager); // Identity
}
catch (Exception ex)
{
    logger.LogError(ex, "An error ocurring during migration");
}

app.Run();
