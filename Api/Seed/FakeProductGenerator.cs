using Api.Models;
using Bogus;

namespace Api.Seed;

public static class FakeProductGenerator
{
    public static List<Product> GenerateProductList(int count = 10)
    {
        var products = new List<Product>();

        var categories = new[] { "Категория 1", "Категория 2", "Категория 3" };
        var specialTags = new[] { "Новинка", "Популярные", "Рекомендуемые" };

        return new Faker<Product>("ru")
            .RuleFor(m => m.Id, f => f.IndexFaker + 1)
            .RuleFor(m => m.Name, f => f.Commerce.ProductName())
            .RuleFor(m => m.Description, f => f.Lorem.Sentence())
            .RuleFor(m => m.SpecialTag, f => f.PickRandom(specialTags))
            .RuleFor(m => m.Category, f => f.PickRandom(categories))
            .RuleFor(m => m.Price, f => Math.Round(f.Random.Decimal(1, 1000), 2))
            .RuleFor(m => m.Image, f => $"https://s3.timeweb.cloud/c57cd5f2-81f2b807-e48f-465d-8404-4a831602b204/img{f.IndexFaker}.png")
            .Generate(count);
    }
}