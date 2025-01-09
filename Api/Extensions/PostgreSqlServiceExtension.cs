using Microsoft.EntityFrameworkCore;

public static class PostgreSqlServiceExtension
{
    public static void AddPostgreSqlDbContext(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(
            options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("PostgreSQLConnection"));
            }
        );
    }
}