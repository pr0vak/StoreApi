using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Services.PaymentService
{
    public class FakePaymentService : IPaymentService
    {
        public Task<ActionResult<ServerResponse>> HandlePaymentAsync(string userId, 
            int orderHeaderId, string cardNumber)
        {
            throw new NotImplementedException();
        }
    }
}
