namespace Hackathon.Manager.Api.Infra.Configurations;

public static class CorsConfiguration
{
    public static IServiceCollection ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(config =>
        {
            config.AddPolicy("CorsPolicy", option =>
            {
                option
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(_ => true)
                    .AllowCredentials();
            });
        });

        return services;
    }
}