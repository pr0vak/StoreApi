using System.Net;
using Api.Common;
using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Payment;

public class FakePaymentService : IPaymentService
{
    private readonly AppDbContext dbContext;

    public FakePaymentService(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<ActionResult<ServerResponse>> HandlePaymentAsync(string userId,
        int orderHeaderId, string cardNumber)
    {
        ShoppingCart shoppingCart = await dbContext.ShoppingCarts
            .Include(cart => cart.CartItems)
            .ThenInclude(cartItem => cartItem.Product)
            .FirstOrDefaultAsync(cart => cart.UserId.Equals(userId));

        if (shoppingCart is null || shoppingCart.CartItems is null
            || shoppingCart.CartItems.Count == 0)
        {
            return new BadRequestObjectResult(new ServerResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Корзина пуста или не найдена" }
            });
        }

        shoppingCart.TotalAmount = shoppingCart.CartItems
            .Sum(cartItem => cartItem.Product.Price * cartItem.Quantity);

        OrderHeader orderHeader = await dbContext.OrderHeaders.FindAsync(orderHeaderId);

        if (orderHeader is null)
        {
            return new BadRequestObjectResult(new ServerResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Такого заказа не существует" }
            });
        }

        await Task.Delay(5000);

        var paymentResponse = new PaymentResponse();

        if (cardNumber.Equals("1111 2222 3333 4444"))
        {
            paymentResponse.Success = true;
            paymentResponse.IntentId = $"fake_intent_id_{Guid.NewGuid()}";
            paymentResponse.Secret = $"secret_{Guid.NewGuid()}";
        }
        else
        {
            paymentResponse.Success = false;
            paymentResponse.IntentId = string.Empty;
            paymentResponse.Secret = string.Empty;
            paymentResponse.ErrorMessage = "Недействительная карта";
        }

        if (!paymentResponse.Success)
        {
            return new BadRequestObjectResult(new ServerResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { paymentResponse.ErrorMessage },
                Result = paymentResponse
            });
        }

        orderHeader.Status = SharedData.OrderStatus.ReadyToShip;

        await dbContext.SaveChangesAsync();

        return new OkObjectResult(new ServerResponse
        {
            StatusCode = HttpStatusCode.OK,
            Result = orderHeader
        });
    }
}