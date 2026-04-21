using VendingMachine.Service.Configuration;

var builder = WebApplication.CreateBuilder(args);

// ========================================
// CONFIGURACIÓN DE SERVICIOS
// ========================================

builder.Services.AddControllers();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddCorsConfiguration();
builder.Services.AddApplicationServices();

var app = builder.Build();

// ========================================
// CONFIGURACIÓN DEL PIPELINE
// ========================================

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.MapControllers();

app.Run();
