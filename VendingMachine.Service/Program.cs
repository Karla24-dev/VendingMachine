using Scalar.AspNetCore;
using VendingMachine.Shared.Configuration;
using VendingMachine.Shared.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// ========================================
// CONFIGURACIÓN DE SERVICIOS
// ========================================

builder.Services.AddControllers();
builder.Services.AddScalarConfiguration();
builder.Services.AddCorsConfiguration();
builder.Services.AddApplicationServices();

var app = builder.Build();

// ========================================
// CONFIGURACIÓN DEL PIPELINE
// ========================================

if (app.Environment.IsDevelopment())
{
    app.UseScalarConfiguration();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.MapControllers();

app.Run();
