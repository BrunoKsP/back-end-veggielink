using Microsoft.OpenApi.Models;

namespace VeggieLink.Api.Configurations;

public static class SwaggerConfig
{
    public static void SwaggerServiceConfig(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(swg =>
        {
            swg.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Api VeggieLink",
            });
            swg.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Autenticação JWT. Exemplo: Bearer {token}"
            });
            swg.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
            });
        });
    }

    public static void SwaggerApplicationConfig(this WebApplication app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(s =>
        {
            s.SwaggerEndpoint($"{Environment.GetEnvironmentVariable("BASE_PATH") ?? ""}/swagger/v1/swagger.json", "Api Veggie Link");
        });
    }
}