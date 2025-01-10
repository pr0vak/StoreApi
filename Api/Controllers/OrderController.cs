using System.Net;
using Api.Data;
using Api.ModelDto;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

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
        [FromBody] OrderHeaderCreateDto orderHeaderCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ServerResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Неверное состояние модели заказа" }
            });
        }

        try
        {
            var order = await ordersService.CreateOrderAsync(orderHeaderCreateDto);

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
                ErrorMessages = { "Невероятная ошибка", ex.Message }
            });
        }
    }
}