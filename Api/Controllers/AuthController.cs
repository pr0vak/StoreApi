using System.Net;
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
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly UserManager<AppUser> userManager;
    private readonly JwtTokenGenerator jwtTokenGenerator;

    public AuthController(AppDbContext dbContext,
        RoleManager<IdentityRole> roleManager,
        UserManager<AppUser> userManager,
        JwtTokenGenerator jwtTokenGenerator)
        : base(dbContext)
    {
        this.roleManager = roleManager;
        this.userManager = userManager;
        this.jwtTokenGenerator = jwtTokenGenerator;
    }

    [HttpPost]
    public async Task<IActionResult> Register(
        [FromBody] UserRegisterDto userRegisterDto)
    {
        if (userRegisterDto == null)
        {
            return BadRequest(new ServerResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Модель регистрации не валидна" }
            });
        }

        var userFromDb = await dbContext.AppUsers
            .FirstOrDefaultAsync(u =>
            u.NormalizedUserName.Equals(userRegisterDto.UserName.ToUpper()));

        if (userFromDb != null)
        {
            return BadRequest(new ServerResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Пользователь с таким именем уже существует" }
            });
        }

        var newAppUser = new AppUser
        {
            UserName = userRegisterDto.UserName,
            Email = userRegisterDto.Email,
            NormalizedEmail = userRegisterDto.Email.ToUpper(),
            FirstName = userRegisterDto.UserName
        };

        var result = await userManager
            .CreateAsync(newAppUser, userRegisterDto.Password);

        if (!result.Succeeded)
        {
            return BadRequest(new ServerResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Ошибка регистрации." }
            });
        }

        var newRoleAppUser = userRegisterDto.Role.Equals(
            SharedData.Roles.Admin, StringComparison.OrdinalIgnoreCase) ?
            SharedData.Roles.Admin : SharedData.Roles.Consumer;

        await userManager.AddToRoleAsync(newAppUser, newRoleAppUser);

        return Ok(new ServerResponse()
        {
            StatusCode = HttpStatusCode.Created,
            Result = "Регистрация завершена"
        });

    }

    [HttpPost]
    public async Task<ActionResult<ServerResponse>> Login(
        [FromBody] LoginRequestDto loginRequestDto)
    {
        var userFromDb = await dbContext.AppUsers
            .FirstOrDefaultAsync(u =>
                u.NormalizedEmail == loginRequestDto.Email.ToUpper());

        if (userFromDb == null || !await userManager
            .CheckPasswordAsync(userFromDb, loginRequestDto.Password))
        {
            return BadRequest(new ServerResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Неверный логин или пароль" }
            });
        }

        var roles = await userManager.GetRolesAsync(userFromDb);
        var token = jwtTokenGenerator.GenerateJwtToken(userFromDb, roles);

        return Ok(new ServerResponse()
        {
            StatusCode = HttpStatusCode.OK,
            Result = new LoginResponseDto()
            {
                Email = userFromDb.Email,
                Token = token
            }
        });
    }
}
