using Hackathon.Manager.Api.Domain.Interfaces.Services;
using Hackathon.Manager.Api.Domain.Interfaces.Repositories;
using Hackathon.Manager.Api.Infra.Repositories;
using Hackathon.Manager.Api.Services;

namespace Hackathon.Manager.Api.Infra.Configurations;

public static class ConfigureDependencyInjection
{
    public static IServiceCollection ConfigDependencyInjection(this IServiceCollection services)
    {
        services.AddTransient<ICognitoService, CognitoService>();
        services.AddTransient<IEmployeeService, EmployeeService>();

        services.AddTransient<IEmployeeRepository, EmployeeRepository>();

        return services;
    }
}