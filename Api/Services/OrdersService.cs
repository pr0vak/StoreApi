using Api.Common;
using Api.Data;
using Api.ModelDto;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;

public class OrdersService
{
    private readonly AppDbContext dbContext;

    public OrdersService(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<OrderHeader> CreateOrderAsync(OrderHeaderCreateDto orderHeaderCreateDto)
    {
        var order = new OrderHeader
        {
            AppUserId = orderHeaderCreateDto.AppUserId,
            CustomerName = orderHeaderCreateDto.CustomerName,
            CustomerEmail = orderHeaderCreateDto.CustomerEmail,
            OrderTotalAmount = orderHeaderCreateDto.OrderTotalAmount,
            TotalCount = orderHeaderCreateDto.TotalCount,
            OrderDateTime = DateTime.UtcNow,
            Status = string.IsNullOrEmpty(orderHeaderCreateDto.Status)
                ? SharedData.OrderStatus.Pending
                : orderHeaderCreateDto.Status
        };

        await dbContext.OrderHeaders.AddAsync(order);
        await dbContext.SaveChangesAsync();

        foreach (var orderDetailsDto in orderHeaderCreateDto.OrderDetailsDto)
        {
            var orderDetails = new OrderDetails
            {
                OrderHeaderId = order.OrderHeaderId,
                ProductId = orderDetailsDto.ProductId,
                ItemName = orderDetailsDto.ItemName,
                Quantity = orderDetailsDto.Quantity,
                Price = orderDetailsDto.Price
            };

            await dbContext.OrderDetails.AddAsync(orderDetails);
        }

        await dbContext.SaveChangesAsync();

        return order;
    }

    public async Task<OrderHeader> GetOrderByIdAsync(int id)
    {
        return await dbContext.OrderHeaders
            .Include(orderHeader => orderHeader.OrderDetailItems)
            .ThenInclude(orderDetails => orderDetails.Product)
            .FirstOrDefaultAsync(u => u.OrderHeaderId == id);
    }

    public async Task<IEnumerable<OrderHeader>> GetOrderByUserIdAsync(string userId)
    {
        var query = dbContext.OrderHeaders
            .Include(orderHeader => orderHeader.OrderDetailItems)
            .ThenInclude(orderDetails => orderDetails.Product)
            .OrderByDescending(orderHeader => orderHeader.AppUserId);

        if (!string.IsNullOrEmpty(userId))
        {
            return await query
            .Where(orderHeader => orderHeader.AppUserId
                .Equals(userId))
            .ToListAsync();
        }

        return await query.ToListAsync();
    }

    public async Task<bool> UpdateOrderHeaderAsync(int id, OrderHeaderUpdateDto orderHeaderUpdateDto)
    {
        if (orderHeaderUpdateDto is null || orderHeaderUpdateDto.OrderHeaderId != id)
        {
            return false;
        }

        var orderHeader = await dbContext.OrderHeaders
            .FirstOrDefaultAsync(ordersHeader => ordersHeader.OrderHeaderId == id);

        if (orderHeader is null)
        {
            return false;
        }

        if (!string.IsNullOrEmpty(orderHeaderUpdateDto.CustomerName))
        {
            orderHeader.CustomerName = orderHeaderUpdateDto.CustomerName;
        }

        if (!string.IsNullOrEmpty(orderHeaderUpdateDto.CustomerEmail))
        {
            orderHeader.CustomerEmail = orderHeaderUpdateDto.CustomerEmail;
        }

        if (!string.IsNullOrEmpty(orderHeaderUpdateDto.Status))
        {
            orderHeader.Status = orderHeaderUpdateDto.Status;
        }

        await dbContext.SaveChangesAsync();
        return true;
    }
}