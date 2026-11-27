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
            Result = await DbContext.Products.ToListAsync()
        });
    }

    [HttpGet("{id:int}", Name = nameof(GetProductById))]
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

        var product = await DbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

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
        if (ModelState.IsValid)
        {
            try
            {
                if (string.IsNullOrEmpty(productCreateDto.Image))
                {
                    return BadRequest(new ServerResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorMessages = ["Image не может быть пустым."]
                    });
                }
                else
                {
                    Product product = new()
                    {
                        Name = productCreateDto.Name,
                        Description = productCreateDto.Description,
                        SpecialTag = productCreateDto.SpecialTag,
                        Category = productCreateDto.Category,
                        Price = productCreateDto.Price,
                        Image = "https://devtool.tech/api/placeholder/250/250",
                    };

                    await DbContext.Products.AddAsync(product);
                    await DbContext.SaveChangesAsync();

                    ServerResponse response = new()
                    {
                        StatusCode = HttpStatusCode.Created,
                        Result = product
                    };

                    return CreatedAtRoute(
                        nameof(GetProductById),
                        new { id = product.Id },
                        response
                    );
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = ["Что-то пошло не так.", ex.Message]
                });
            }
        }
        else
        {
            return BadRequest(new ServerResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = ["Модель данных product не валидна."]
            });
        }
    }
}
