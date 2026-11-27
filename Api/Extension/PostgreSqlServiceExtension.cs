using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Extension;

public static class PostgreSqlServiceExtension
{
    extension(IServiceCollection services)
    {
        public void AddPostgreSqlDbContext(IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("PostgreSQLConnection")
                );
            });
        }

        public void AddPostgreSqlIdentityContext()
        {
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
