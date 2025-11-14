using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Api.Services.PaymentService
{
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
            var shoppingCart = await dbContext.ShoppingCarts
                .Include(shoppingCart => shoppingCart.CartItems)
                .ThenInclude(cartItem => cartItem.Product)
                .FirstOrDefaultAsync(shoppingCart => shoppingCart.UserId == userId);

            if (shoppingCart == null || shoppingCart.CartItems == null
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
                .Sum(cartItem => cartItem.Quantity * cartItem.Product.Price);

            var orderHeader = await dbContext.OrderHeaders
                .FindAsync(orderHeaderId);

            if (orderHeader == null)
            {
                return new BadRequestObjectResult(new ServerResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = { "Такого заказа не существует" }
                });
            }

            PaymentResponse paymentResponse;

            if (cardNumber == "1111 2222 3333 4444")
            {
                paymentResponse = new PaymentResponse
                {
                    Success = true,
                    IntentId = "fake_intent_id",
                    Secret = "fake_secret"
                };
            }
            else
            {
                paymentResponse = new PaymentResponse
                {
                    Success = false,
                    IntentId = String.Empty,
                    Secret = String.Empty,
                    ErrorMessage = "Недействительная карта"
                };
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

            orderHeader.Status = SharedData.Statuses.ReadyToShip;

            await dbContext.SaveChangesAsync();

            return new OkObjectResult(new ServerResponse
            {
                StatusCode = HttpStatusCode.OK,
                Result = paymentResponse
            });
        }
    }
}
