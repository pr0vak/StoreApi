using Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase
{
    protected readonly AppDbContext dbContext;

    public StoreController(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
}