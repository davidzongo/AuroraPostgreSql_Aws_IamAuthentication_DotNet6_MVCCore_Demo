using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RdsPostgreSqlAwsIamAuthenticationDotNet6Demo.Data;

namespace RdsPostgreSqlAwsIamAuthenticationDotNet6Demo.Extensions
{
    public static class DatabaseMigrator
    {
        public static WebApplication MigrateDbOnStartup(this WebApplication app)
        {

            using (IServiceScope? scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                DemoDbContext? context = scope.ServiceProvider.GetService<DemoDbContext>();
                if (context == null)
                {
                    throw new InvalidOperationException("database context is null");
                }
                var database = context.Database;
                if (database != null && database.GetPendingMigrations().Any())
                {
                    database.Migrate();
                }
            }
            return app;
        }

	}
}
