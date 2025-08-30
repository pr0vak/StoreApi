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

    [HttpGet("{id}", Name = nameof(GetProductById))]
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

    [HttpPost]
    public async Task<ActionResult<ServerResponse>> CreateProduct(
        [FromBody] ProductCreateDto productCreateDto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (productCreateDto.Image is null
                    || productCreateDto.Image.Trim().Length == 0)
                {
                    return BadRequest(new ServerResponse()
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorMessages = { "Image не может быть пустым" }
                    });
                }
                else
                {
                    Product product = new()
                    {
                        Name = productCreateDto.Name,
                        Description = productCreateDto.Description,
                        Category = productCreateDto.Category,
                        SpecialTag = productCreateDto.SpecialTag,
                        Price = productCreateDto.Price,
                        Image = "https://placehold.co/200x150"
                    };

                    await dbContext.Products.AddAsync(product);
                    await dbContext.SaveChangesAsync();

                    var response = new ServerResponse()
                    {
                        StatusCode = HttpStatusCode.Created,
                        Result = product
                    };

                    return CreatedAtRoute(nameof(GetProductById), new { id = product.Id }, response);
                }
            }
            else
            {
                return BadRequest(new ServerResponse()
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = { "Данные модели не валидны" }
                });
            }
        }
        catch (Exception ex)
        {
            return BadRequest(new ServerResponse()
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Что-то пошло не так...", ex.Message }
            });
        }
    }
}

