using System.Net;
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

    [HttpGet]
    public ActionResult<ServerResponse> Test1()
    {
        return Ok(new ServerResponse
        {
            StatusCode = HttpStatusCode.OK,
            Result = "Test1: Для всех."
        });
    }

    [HttpGet]
    [Authorize] 
    public ActionResult<ServerResponse> Test2()
    {
        return Ok(new ServerResponse
        {
            StatusCode = HttpStatusCode.OK,
            Result = "Test2: Для авторизованных пользователей."
        });
    }

    [HttpGet]
    [Authorize(Roles = SharedData.Roles.Consumer)]
    public ActionResult<ServerResponse> Test3()
    {
        return Ok(new ServerResponse
        {
            StatusCode = HttpStatusCode.OK,
            Result = "Test3: Для авторизованных пользователей с ролью Consumer."
        });
    }

    [HttpGet]
    [Authorize(Roles = SharedData.Roles.Admin)]
    public ActionResult<ServerResponse> Test4()
    {
        return Ok(new ServerResponse
        {
            StatusCode = HttpStatusCode.OK,
            Result = "Test1: Для авторизованных пользователей с ролью Admin."
        });
    }
}
