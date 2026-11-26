using Microsoft.AspNetCore.Identity;

namespace Api.Models;

public class AppUser : IdentityUser
{
    public required string FirstName { get; set; }
}
