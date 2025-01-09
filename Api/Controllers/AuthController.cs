using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Identity;

namespace Api.Controllers;

public class AuthController : StoreController
{
    private readonly UserManager<AppUser> userManager;
    private readonly RoleManager<IdentityRole> roleManager;

    public AuthController(AppDbContext dbContext, UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager) : base(dbContext)
    {
        this.roleManager = roleManager;
        this.userManager = userManager;
    }
}
