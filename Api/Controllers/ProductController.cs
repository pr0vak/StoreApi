using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public class ProductController(AppDbContext dbContext)
    : StoreController(dbContext)
{
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        return Ok(await dbContext.Products.ToListAsync());
    }
}
