using BookRental.Infrastructure.Extensions;
using BookRental.Infrastructure.Seeders;
using BookRental.Application.Extensions;
using Serilog;
using BookRental.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Host.UseSerilog((context, configuration) => 
                        configuration.MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
                                     .MinimumLevel.Override("Microsoft.EntityFrameworkCore", Serilog.Events.LogEventLevel.Information)
                                     .WriteTo.File("Log/BookLogInfo-.log", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
                                     .WriteTo.Console());

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IBookSeeder>();
await seeder.Seed();

app.UseMiddleware<ErrorHandlingMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
