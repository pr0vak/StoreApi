using System.Net;
using Api.Common;
using Api.Data;
using Api.ModelDto;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public class AuthController : StoreController
{
    private readonly UserManager<AppUser> userManager;
    private readonly RoleManager<IdentityRole> roleManager;
    public readonly JwtTokenGenerator jwtTokenGenerator;

    public AuthController(AppDbContext dbContext, UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager, JwtTokenGenerator jwtTokenGenerator) : base(dbContext)
    {
        this.jwtTokenGenerator = jwtTokenGenerator;
        this.roleManager = roleManager;
        this.userManager = userManager;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
    {
        if (registerRequestDto is null)
        {
            return BadRequest(new ServerResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Некорректная модель запроса" }
            });
        }

        var userFromDb = await dbContext.AppUsers.FirstOrDefaultAsync(u =>
            u.NormalizedUserName.Equals(registerRequestDto.UserName.ToUpper()));

        if (userFromDb is not null)
        {
            return BadRequest(new ServerResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Такой пользователь есть" }
            });
        }

        var newAppUser = new AppUser
        {
            UserName = registerRequestDto.UserName,
            Email = registerRequestDto.Email,
            NormalizedEmail = registerRequestDto.Email.ToUpper(),
            FirstName = registerRequestDto.UserName
        };

        var result = await userManager.CreateAsync(newAppUser, registerRequestDto.Password);

        if (!result.Succeeded)
        {
            return BadRequest(new ServerResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Ошибка регистрации" }
            });
        }

        var newRoleAppUser = registerRequestDto.Role
            .Equals(SharedData.Roles.Admin, StringComparison.OrdinalIgnoreCase)
            ? SharedData.Roles.Admin
            : SharedData.Roles.Consumer;

        await userManager.AddToRoleAsync(newAppUser, newRoleAppUser);
        return Ok(new ServerResponse
        {
            StatusCode = HttpStatusCode.OK,
            Result = "Регистрация завершена"
        });
    }

    [HttpPost("Login")]
    public async Task<ActionResult<ServerResponse>> Login([FromBody] LoginRequestDto loginRequestDto)
    {
        var userFromDb = await dbContext.AppUsers
            .FirstOrDefaultAsync(u => u.Email.ToLower() == loginRequestDto.Email.ToLower());
        if (userFromDb is null
            || !await userManager.CheckPasswordAsync(userFromDb, loginRequestDto.Password))
        {
            return BadRequest(new ServerResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Такого пользователя нет" }
            });
        }

        var roles = await userManager.GetRolesAsync(userFromDb);
        var token = jwtTokenGenerator.GenerateJwtToken(userFromDb, roles);

        return Ok(new ServerResponse
        {
            StatusCode = HttpStatusCode.OK,
            Result = new LoginResponseDto
            {
                Email = userFromDb.Email,
                Token = token
            }
        });
    }
}
