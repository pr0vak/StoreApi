using System.Net;
using Api.Data;
using Api.ModelDto;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class OrderController : StoreController
    {
        private readonly OrdersService ordersService;

        public OrderController(AppDbContext dbContext, OrdersService ordersService)
            : base(dbContext)
        {
            this.ordersService = ordersService;
        }

        [HttpPost]
        public async Task<ActionResult<ServerResponse>> CreateOrder(
            [FromBody] OrderHeaderCreateDto orderDetailsCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ServerResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = { "Невалидная модель данных." }
                });
            }

            try
            {
                var order = await ordersService.CreateOrderAsync(orderDetailsCreateDto);

                return Ok(new ServerResponse
                {
                    StatusCode = HttpStatusCode.Created,
                    Result = order
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = { "Что-то пошло не так...", ex.Message }
                });
            }
        }
    }
}

