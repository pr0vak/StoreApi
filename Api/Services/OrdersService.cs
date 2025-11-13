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

    public async Task<OrderHeader> CreateOrderAsync(
        OrderHeaderCreateDto orderHeaderCreateDto)
    {
        var order = new OrderHeader
        {
            CustomerName = orderHeaderCreateDto.CustomerName,
            CustomerEmail = orderHeaderCreateDto.CustomerEmail,
            AppUserId = orderHeaderCreateDto.AppUserId,
            OrderTotalAmount = orderHeaderCreateDto.OrderTotalAmount,
            OrderDateTime = DateTime.UtcNow,
            TotalCount = orderHeaderCreateDto.TotalCount,
            Status = string.IsNullOrWhiteSpace(orderHeaderCreateDto.Status)
                ? SharedData.Statuses.Pending
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
                Quantity = orderDetailsDto.Quantity,
                ItemName = orderDetailsDto.ItemName,
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
            .FirstOrDefaultAsync(orderHeader => orderHeader.OrderHeaderId == id);
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
                .Where(orderHeader => orderHeader.AppUserId == userId)
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

        var orderHeaderFromDb = await dbContext.OrderHeaders
            .FirstOrDefaultAsync(o => o.OrderHeaderId == id);

        if (orderHeaderFromDb is null)
        {
            return false;
        }

        if (!string.IsNullOrWhiteSpace(orderHeaderUpdateDto.CustomerName))
        {
            orderHeaderFromDb.CustomerName = orderHeaderUpdateDto.CustomerName;
        }

        if (!string.IsNullOrWhiteSpace(orderHeaderUpdateDto.CustomerEmail))
        {
            orderHeaderFromDb.CustomerEmail = orderHeaderUpdateDto.CustomerEmail;
        }

        if (!string.IsNullOrWhiteSpace(orderHeaderUpdateDto.Status))
        {
            orderHeaderFromDb.Status = orderHeaderUpdateDto.Status;
        }

        await dbContext.SaveChangesAsync();

        return true;
    }
}
