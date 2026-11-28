using Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class StoreController(AppDbContext dbContext) : ControllerBase
    {
        protected readonly AppDbContext DbContext = dbContext;
    }
}
