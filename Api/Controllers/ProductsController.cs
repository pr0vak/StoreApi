using Api.Data;
using Api.Models;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.ModelDto;
using Api.Storage;

namespace Api.Controllers;

public class ProductsController : StoreController
{
    private readonly IFileStorageService fileStorage;

    public ProductsController(AppDbContext dbContext, IFileStorageService fileStorage) : base(dbContext)
    {
        this.fileStorage = fileStorage;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        ServerResponse response = new ServerResponse
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
        ServerResponse response = new ServerResponse();
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
    public async Task<ActionResult<ServerResponse>> CreateProduct(
        [FromForm] ProductCreateDto productCreateDto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (productCreateDto.Image is null
                    || productCreateDto.Image.Length == 0)
                {
                    return BadRequest(new ServerResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorMessages = { "Image не может быть пустым" }
                    });
                }

                Product item = new()
                {
                    Name = productCreateDto.Name,
                    Description = productCreateDto.Description,
                    SpecialTag = productCreateDto.SpecialTag,
                    Category = productCreateDto.Category,
                    Price = productCreateDto.Price,
                    Image = await fileStorage.UploadFileAsync(productCreateDto.Image)
                };

                await dbContext.Products.AddAsync(item);
                await dbContext.SaveChangesAsync();

                ServerResponse response = new ServerResponse
                {
                    StatusCode = HttpStatusCode.Created,
                    Result = item
                };
                return CreatedAtRoute(nameof(GetProductById), new { id = item.Id }, response);
            }

            return BadRequest(new ServerResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Модель данных не подходит" }
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ServerResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Ошибка сервера", ex.Message }
            });
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServerResponse>> UpdateProduct(
        int id, [FromForm] ProductUpdateDto productUpdateDto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (productUpdateDto is null
                    || productUpdateDto.Id != id)
                {
                    return BadRequest(new ServerResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorMessages = { "Несоответствие модели данных" }
                    });
                }

                Product productFromDb = await dbContext.Products.FindAsync(id);

                if (productFromDb is null)
                {
                    return NotFound(new ServerResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.NotFound,
                        ErrorMessages = { "Продукт с таким id не найден" }
                    });
                }

                productFromDb.Name = productUpdateDto.Name;
                productFromDb.Description = productUpdateDto.Description;
                productFromDb.Category = productUpdateDto.Category;
                productFromDb.SpecialTag = productUpdateDto.SpecialTag;
                productFromDb.Price = productUpdateDto.Price;

                if (productUpdateDto.Image is not null && productUpdateDto.Image.Length > 0)
                {
                    await fileStorage.RemoveFileAsync(productFromDb.Image.Split("/").Last());
                    productFromDb.Image = await fileStorage.UploadFileAsync(productUpdateDto.Image);
                }

                dbContext.Products.Update(productFromDb);
                await dbContext.SaveChangesAsync();

                return Ok(new ServerResponse
                {
                    StatusCode = HttpStatusCode.OK,
                    Result = productFromDb
                });
            }

            return BadRequest(new ServerResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Модель данных не подходит" }
            });

        }
        catch (Exception ex)
        {
            return BadRequest(new ServerResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Что-то пошло не так", ex.Message }
            });
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServerResponse>> RemoveProductById(int id)
    {
        try
        {
            if (id <= 0)
            {
                return BadRequest(new ServerResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = { "Неверный id" }
                });
            }

            var product = await dbContext.Products.FindAsync(id);

            if (product is null)
            {
                return NotFound(new ServerResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    ErrorMessages = { "Продукт с таким id не найден" }
                });
            }

            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();

            return Ok(new ServerResponse
            {
                StatusCode = HttpStatusCode.NoContent
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ServerResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Что-то пошло не так", ex.Message }
            });
        }
    }
}
