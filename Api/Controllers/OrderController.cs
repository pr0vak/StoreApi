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

    [HttpGet("GetOrderById/{id}")]
    public async Task<ActionResult<ServerResponse>> GetOrder(int id)
    {
        if (id <= 0)
        {
            return BadRequest(new ServerResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = { "Невероятный идентификатор заказа" }
            });
        }

        try
        {
            var orderHeader = await ordersService.GetOrderByIdAsync(id);

            if (orderHeader is null)
            {
                return NotFound(new ServerResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    ErrorMessages = { "Заказ не найден" }
                });
            }

            return Ok(new ServerResponse
            {
                StatusCode = HttpStatusCode.OK,
                Result = orderHeader
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

    [HttpGet("GetOrdersByUserId/{userId}")]
    public async Task<ActionResult<ServerResponse>> GetOrdersByUserId(string userId)
    {
        try
        {
            var orderHeaders = await ordersService.GetOrderByUserIdAsync(userId);
            return Ok(new ServerResponse
            {
                StatusCode = HttpStatusCode.OK,
                Result = orderHeaders
            });
        }
        catch (Exception ex)
        {
            // Для примера
            return StatusCode((int)HttpStatusCode.InternalServerError,
                new ServerResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.InternalServerError,
                    ErrorMessages = { "При обработке возникла проблема", ex.Message }
                });
        }
    }
}