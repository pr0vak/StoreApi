using Api.Data;
using Api.Models;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public class ProductsController : StoreController
{
    public ProductsController(AppDbContext dbContext) : base(dbContext)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        ResponseServer response = new ResponseServer
        {
            StatusCode = HttpStatusCode.OK,
            Result = await dbContext.Products.ToListAsync()
        };
        return Ok(response);
    }
}
