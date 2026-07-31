using DotNetEnv;
using Medications.Api.Persistence;
using Medications.Api.Persistence.Repositories;
using Medications.Api.Persistence.Repositories.Abstractions;
using Medications.Api.Services;
using Medications.Api.Services.Abstractions;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MedicationsDbContext>();
builder.Services.AddTransient<IMedicationsService, MedicationsService>();
builder.Services.AddTransient<IMedicationsRepository, MedicationsRepository>();
builder.Services.AddControllers();

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

app.Run();
