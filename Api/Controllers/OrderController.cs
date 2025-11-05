using Api.Data;
using Api.Services;

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
    }
}
