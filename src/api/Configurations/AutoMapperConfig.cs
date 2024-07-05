using VeggieLink.Aplication.AutoMapper;

namespace VeggieLink.Api.Configurations;

public static class AutoMapperConfig
{
    public static void AutoMapperServiceConfig(this IServiceCollection services, IConfiguration config)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        var mappginConfig = AutoMapperSetup.RegisterMappings(config);
        var mapper = mappginConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}