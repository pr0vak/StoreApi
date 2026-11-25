using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ProductController : StoreController
    {

        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            await Task.Delay(1000);
            return Ok(await Task.FromResult<string>("Hello world"));
        }
    }
}
