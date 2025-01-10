using System.Net;
using Api.Data;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

public class ShoppingCartController : StoreController
{
    private readonly ShoppingCartService shoppingCartService;

    public ShoppingCartController(AppDbContext dbContext,
        ShoppingCartService shoppingCartService) : base(dbContext)
    {
        this.shoppingCartService = shoppingCartService;
    }

    [HttpGet("AppendOrUpdateShoppingCart/userId={userId}&productId={productId}&updateQuantity={updateQuantity}")]
    public async Task<ActionResult<ServerResponse>> AppendOrUpdateItemInCart(
        string userId, int productId, int updateQuantity)
    {
        Product productFromDb = await dbContext.Products
            .FirstOrDefaultAsync(p => p.Id == productId);

        if (productFromDb is null)
        {
            return BadRequest(new ServerResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Такого товара не найдено" }
            });
        }

        ShoppingCart shoppingCart = await dbContext.ShoppingCarts
            .Include(c => c.CartItems)
            .ThenInclude(ci => ci.Product)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (shoppingCart is null && updateQuantity > 0)
        {
            await shoppingCartService.CreateNewCartAsync(userId, productId, updateQuantity);
        }
        else if (shoppingCart is not null)
        {
            await shoppingCartService.UpdateExistingCartAsync(shoppingCart, productId, updateQuantity);
        }

        return Ok(new ServerResponse
        {
            StatusCode = HttpStatusCode.OK
        });
    }

    [HttpGet("GetShoppingCart/userId={userId}")]
    public async Task<ActionResult<ServerResponse>> GetShoppingCart(string userId)
    {
        try
        {
            ShoppingCart shoppingCart = await shoppingCartService.GetShoppingCartAsync(userId);

            return Ok(new ServerResponse
            {
                StatusCode = HttpStatusCode.OK,
                Result = shoppingCart
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ServerResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Ошибка получения корзины", ex.Message }
            });
        }
    }
}