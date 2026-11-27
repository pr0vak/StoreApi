using Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class StoreController : ControllerBase
    {
        protected readonly AppDbContext DbContext;

        public StoreController(AppDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
    }
}
