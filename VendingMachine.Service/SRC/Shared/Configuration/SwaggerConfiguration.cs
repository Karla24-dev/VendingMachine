namespace VendingMachine.Service.Configuration;

using Microsoft.OpenApi;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "VendingMachine API",
                Version = "v1",
                Description = "API para gestión de máquinas expendedoras",
                Contact = new OpenApiContact
                {
                    Name = "KarlaBaron",
                    Email = "tu@email.com"
                }
            });

        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "VendingMachine API v1");
            options.RoutePrefix = "swagger"; // URL: /swagger
            options.DocumentTitle = "VendingMachine API";
        });

        return app;
    }
}
