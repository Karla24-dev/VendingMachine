using VendingMachine.Service.Machines.Service;
using VendingMachine.Service.Modules.Machines.Application.Interfaces;
using VendingMachine.Service.Modules.Machines.Application.Services;
using VendingMachine.Service.Shared;
using Microsoft.EntityFrameworkCore;
using VendingMachine.Service.Shared.db.Service;

namespace VendingMachine.Service.Configuration;


public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Google Sheets Service
        services.AddSingleton<Factory>();
        // Repositories
        services.AddDbContext<VendingDbContext>((serviceProvider, options) =>
                {
                    var factory = serviceProvider.GetRequiredService<Factory>();
                    options.UseNpgsql(factory.GetConnectionString());
                });
        services.AddScoped<IMachineRepository, EfMachineRepository>();

        // Services
        services.AddScoped<MachineService>();

        return services;
    }
}
