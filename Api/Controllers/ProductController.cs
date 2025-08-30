using System.Net;
using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public class ProductController : StoreController
{
    public ProductController(AppDbContext dbContext) : base(dbContext)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        return Ok(new ServerResponse
        {
            StatusCode = HttpStatusCode.OK,
            Result = await dbContext.Products.ToListAsync()
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetProductById(int id)
    {
        if (id <= 0)
            return BadRequest(new ServerResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Некорректно введен Id продукта." }
            });

        var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

        if (product is null)
            return NotFound(new ServerResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.NotFound,
                ErrorMessages = { "Продукт с таким Id не существует." }
            });

        return Ok(new ServerResponse()
        {
            StatusCode = HttpStatusCode.OK,
            Result = product
        });
    }
}

