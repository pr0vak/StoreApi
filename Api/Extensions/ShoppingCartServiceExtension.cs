using Api.Services;

namespace Api.Extensions;

public static class ShoppingCartServiceExtension
{
    public static IServiceCollection AddShoppingCartService(this IServiceCollection services)
    {
        return services.AddScoped<ShoppingCartService>();
    }
}