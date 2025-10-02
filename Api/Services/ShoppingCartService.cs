using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;

public class ShoppingCartService
{
    private readonly AppDbContext _dbContext;

    public ShoppingCartService(AppDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task CreateNewCartAsync(string userId,
        int productId, int quantity)
    {
        ShoppingCart newCart = new ShoppingCart
        {
            UserId = userId
        };

        await _dbContext.ShoppingCarts.AddAsync(newCart);
        await _dbContext.SaveChangesAsync();

        CartItem newCartItem = new CartItem
        {
            ProductId = productId,
            Quantity = quantity,
            ShoppingCartId = newCart.Id,
            Product = null
        };

        await _dbContext.CartItems.AddAsync(newCartItem);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateExistingCartAsync(ShoppingCart shoppingCart,
        int productId, int newQuantity)
    {
        CartItem cartItemInCart = shoppingCart.CartItems
            .FirstOrDefault(i => i.ProductId == productId);

        if (cartItemInCart is null && newQuantity > 0)
        {
            CartItem cartItem = new CartItem
            {
                ProductId = productId,
                Quantity = newQuantity,
                ShoppingCartId = shoppingCart.Id,
                Product = null
            };

            await _dbContext.CartItems.AddAsync(cartItem);
        }
        else if (cartItemInCart is not null)
        {
            int updateQuantity = cartItemInCart.Quantity + newQuantity;

            if (newQuantity == 0 || updateQuantity <= 0)
            {
                _dbContext.CartItems.Remove(cartItemInCart);

                if (shoppingCart.CartItems.Count == 1)
                {
                    _dbContext.ShoppingCarts.Remove(shoppingCart);
                }
            }
            else
            {
                cartItemInCart.Quantity = updateQuantity;
            }
        }

        await _dbContext.SaveChangesAsync();
    }

    public async Task<ShoppingCart> GetShoppingCartAsync(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            return new ShoppingCart();
        }

        ShoppingCart shoppingCart = await _dbContext.ShoppingCarts
            .Include(c => c.CartItems)
            .ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (shoppingCart is not null &&
            shoppingCart.CartItems.Count > 0)
        {
            shoppingCart.TotalAmount = shoppingCart.CartItems
                .Sum(i => i.Quantity * i.Product.Price);       
        }

        return shoppingCart;
    }
}
