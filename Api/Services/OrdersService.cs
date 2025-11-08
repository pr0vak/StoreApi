using Api.Data;
using Api.ModelDto;
using Api.Models;

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
}
