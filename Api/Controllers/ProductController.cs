using System.Net;
using Api.Data;
using Api.ModelDto;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public class ProductController(AppDbContext dbContext) : StoreController(dbContext)
{
    [HttpGet]
    public async Task<ActionResult<ServerResponse>> GetProducts()
    {
        return Ok(new ServerResponse
        {
            StatusCode = HttpStatusCode.OK,
            Result = await dbContext.Products.ToListAsync()
        });
    }

    [HttpGet]
    public async Task<ActionResult<ServerResponse>> GetProductById(int id)
    {
        if (id <= 0)
        {
            return BadRequest(new ServerResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = ["Неверный id."]
            });
        }

        var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return NotFound(new ServerResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.NotFound,
                ErrorMessages = ["Продукт с таким id не найден."]
            });
        }

        return Ok(new ServerResponse
        {
            StatusCode = HttpStatusCode.OK,
            Result = product
        });
    }

    [HttpPost]
    public async Task<ActionResult<ServerResponse>> AppendProduct(
        [FromBody] ProductCreateDto productCreateDto
    )
    {

    }
}
