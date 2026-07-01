using Scalar.AspNetCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Any;

namespace VendingMachine.Shared.Configuration;

public static class ScalarConfiguration
{
    public static IServiceCollection AddScalarConfiguration(this IServiceCollection services)
    {
        services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer((document, context, ct) =>
            {
                document.Info = new()
                {
                    Title = "VendingMachine API",
                    Version = "v1",
                    Description = "API para gestión de máquinas expendedoras"
                };
                return Task.CompletedTask;
            });
            options.AddSchemaTransformer((schema, context, ct) =>
            {
                var type = context.JsonTypeInfo.Type;
                if (type.IsEnum)
                {
                    var names = Enum.GetNames(type);
                    schema.Enum = names
                        .Select(name => new OpenApiString(name))
                        .Cast<IOpenApiAny>()
                        .ToList();
                    schema.Type = "string";
                    schema.Format = null;
                    schema.Example = new OpenApiString(string.Join(" | ", names));
                }
                return Task.CompletedTask;
            });
        });

        return services;
    }

    public static WebApplication UseScalarConfiguration(this WebApplication app)
    {
        app.MapOpenApi();

        app.MapScalarApiReference(options =>
        {
            options.Title = "VendingMachine API";
            options.Theme = ScalarTheme.DeepSpace;
            options.DefaultHttpClient = new(ScalarTarget.CSharp, ScalarClient.HttpClient);
            options.ShowSidebar = true;
            options.DefaultOpenAllTags = false;
            options.TagSorter = TagSorter.Alpha;  // ← ordena módulos alfabéticamente
        });

        return app;
    }
}
