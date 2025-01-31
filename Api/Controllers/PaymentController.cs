using Api.Data;
using Api.Models;
using Api.Services.Payment;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class PaymentController : StoreController
{
    private readonly IPaymentService paymentService;

    public PaymentController(AppDbContext dbContext, IPaymentService paymentService)
        : base(dbContext)
    {
        this.paymentService = paymentService;
    }

    [HttpPost]
    public async Task<ActionResult<ServerResponse>> MakePayment(string userId, int orderHeader,
        string cardNumber)
    {
        return await paymentService.HandlePaymentAsync(userId, orderHeader, cardNumber);
    }

}