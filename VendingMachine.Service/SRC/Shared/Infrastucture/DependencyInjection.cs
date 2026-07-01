using VendingMachine.Service.Modules.Machines.Application.Interfaces;
using VendingMachine.Service.Modules.Machines.Application.Services;
using VendingMachine.Service.Shared;
using Microsoft.EntityFrameworkCore;
using VendingMachine.Service.Shared.db.Service;
using VendingMachine.Products.Servis;
using VendingMachine.Inventories.Servis;
using VendingMachine.Inventories.Servis.Strategies;

namespace VendingMachine.Service.Configuration;


public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Google Sheets Service
        services.AddSingleton<ConnectionStringBuilder>();
        // Repositories
        services.AddDbContext<VendingDbContext>((serviceProvider, options) =>
                {
                    var connectionStringBuilder = serviceProvider.GetRequiredService<ConnectionStringBuilder>();
                    options.UseNpgsql(connectionStringBuilder.GetConnectionString());
                });
        services.AddScoped<IMachineRepository, EfMachineRepository>();

        // Services
        services.AddScoped<MachineService>();
        services.AddScoped<IProductRepository, EfProductRepository>();
        services.AddScoped<ProductService>();

        services.AddScoped<IInventoryRepository, EfInventoryRepository>();
        services.AddScoped<InventoryService>();

        services.AddScoped<IProductRepository, EfProductRepository>();
        services.AddScoped<ProductService>();

        services.AddScoped<InventoryStrategyFactory>();
        services.AddScoped<InventoryProductService>();

        return services;
    }
}
