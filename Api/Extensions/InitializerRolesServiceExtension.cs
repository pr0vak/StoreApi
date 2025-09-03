using Api.SharedData;
using Microsoft.AspNetCore.Identity;

namespace Api.Extensions;

public static class InitializerRolesServiceExtension
{
    public static async Task InitializeRolesAsync(
        this IServiceProvider service)
    {
        await using var scope = service.CreateAsyncScope();
        var roleManager = scope.ServiceProvider
            .GetRequiredService<RoleManager<IdentityRole>>();
        
        foreach (var role in Roles.GetRoles())
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
