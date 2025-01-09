using Api.Data;
using Api.Models;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.ModelDto;

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

    [HttpGet("{id}", Name = nameof(GetProductById))]
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

    [HttpPost]
    public async Task<ActionResult<ResponseServer>> CreateProduct(
        [FromBody] ProductCreateDto productCreateDto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (productCreateDto.Image is null
                    || productCreateDto.Image.Length == 0)
                {
                    return BadRequest(new ResponseServer
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        IsSuccess = false,
                        ErrorMessages = { "Image не может быть пустым" }
                    });
                }
                else
                {
                    Product item = new()
                    {
                        Name = productCreateDto.Name,
                        Description = productCreateDto.Description,
                        SpecialTag = productCreateDto.SpecialTag,
                        Category = productCreateDto.Category,
                        Price = productCreateDto.Price,
                        Image = "https://dummyimage.com/150x150/fff/aaa"
                    };

                    await dbContext.Products.AddAsync(item);
                    await dbContext.SaveChangesAsync();

                    ResponseServer response = new ResponseServer
                    {
                        StatusCode = HttpStatusCode.Created,
                        Result = item
                    };
                    return CreatedAtRoute(nameof(GetProductById), new { id = item.Id }, response);
                }
            }
            else
            {
                return BadRequest(new ResponseServer
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = { "Модель данных не подходит" }
                });
            }
        }
        catch (Exception ex)
        {
            return BadRequest(new ResponseServer
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Ошибка сервера", ex.Message }
            });
        }
    }
}
