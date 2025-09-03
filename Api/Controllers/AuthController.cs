using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Identity;

namespace Api.Controllers
{
    public class AuthController : StoreController
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;

        public AuthController(AppDbContext dbContext,
            RoleManager<IdentityRole> roleManager,
            UserManager<AppUser> userManager) 
            : base(dbContext)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
    }
}
