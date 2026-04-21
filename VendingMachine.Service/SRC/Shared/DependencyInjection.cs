using VendingMachine.Service.Machines.Service;
using VendingMachine.Service.Modules.Machines.Application.Interfaces;
using VendingMachine.Service.Modules.Machines.Application.Services;
using VendingMachine.Service.Shared.db.Service;

namespace VendingMachine.Service.Configuration;


public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Google Sheets Service
        services.AddSingleton<GoogleSheetsService>();
        // Repositories
        services.AddScoped<IMachineRepository, GoogleSheetsMachineRepository>();
        // Services
        services.AddScoped<MachineService>();

        return services;
    }
}
