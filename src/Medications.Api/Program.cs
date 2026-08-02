using DotNetEnv;
using Medications.Api.ExceptionHandling;
using Medications.Api.Persistence;
using Medications.Api.Persistence.Repositories;
using Medications.Api.Persistence.Repositories.Abstractions;
using Medications.Api.Services;
using Medications.Api.Services.Abstractions;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MedicationsDbContext>();
builder.Services.AddScoped<IMedicationService, MedicationService>();
builder.Services.AddScoped<IMedicationRepository, MedicationRepository>();
builder.Services.AddControllers();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS_POLICY", policy =>
    {
        policy.WithOrigins("http://localhost:8080")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseCors("CORS_POLICY");
app.MapControllers();
app.UseExceptionHandler();

app.Run();
