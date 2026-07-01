using VendingMachine.Service.Shared;
using Microsoft.EntityFrameworkCore;
using VendingMachine.Service.Shared.db.Service;
using VendingMachine.Machines.Domain;
using VendingMachine.Machines.Application;
using VendingMachine.Products.Domain;
using VendingMachine.Products.Application;
using VendingMachine.Products.Infraestructure;
using VendingMachine.Inventories.Domain;
using VendingMachine.Inventories.Application;
using VendingMachine.Inventories.Infraestructure;

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
