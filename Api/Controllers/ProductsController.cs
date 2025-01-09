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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        Product product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        ResponseServer response = new ResponseServer();
        if (product is null)
        {
            response.IsSuccess = false;
            response.StatusCode = HttpStatusCode.NotFound;
            response.ErrorMessages.Add("Продукт с данным id не найден.");
            return NotFound(response);
        }

        response.StatusCode = HttpStatusCode.OK;
        response.Result = product;
        return Ok(response);
    }
}
