using Hackathon.Manager.Api.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Manager.Api.Infra.Configurations;

public static class MigrationExtensions
{
    public static void ExecuteMigration(this IServiceProvider provider)
    {
        using (var scope = provider.CreateScope())
        {
            var services = scope.ServiceProvider;

            using (var context = services.GetRequiredService<DataContext>())
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}