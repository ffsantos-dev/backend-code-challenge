using Medications.Api.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MedicationsDbContext>();

var app = builder.Build();


app.Run();