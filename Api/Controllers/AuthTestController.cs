using System.Net;
using Api.Common;
using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class AuthTestController : StoreController
{
    public AuthTestController(AppDbContext dbContext) : base(dbContext)
    {
    }

    [HttpGet("test1")]
    public IActionResult Test1()
    {
        return Ok(new ServerResponse
        {
            StatusCode = HttpStatusCode.OK,
            Result = "Test 1: Для всех"
        });
    }

    [HttpGet("test2")]
    [Authorize]
    public IActionResult Test2()
    {
        return Ok(new ServerResponse
        {
            StatusCode = HttpStatusCode.OK,
            Result = "Test 2: Для авторизованных пользователей"
        });
    }

    [HttpGet("test3")]
    [Authorize(Roles = SharedData.Roles.Consumer)]
    public IActionResult Test3()
    {
        return Ok(new ServerResponse
        {
            StatusCode = HttpStatusCode.OK,
            Result = "Test 3: Для авторизованных пользователей с правами Consumer"
        });
    }

    [HttpGet("test4")]
    [Authorize(Roles = SharedData.Roles.Admin)]
    public IActionResult Test4()
    {
        return Ok(new ServerResponse
        {
            StatusCode = HttpStatusCode.OK,
            Result = "Test 4: Для авторизованных пользователей с правами Admin"
        });
    }
}