using Api.Models;
using Bogus;

namespace Api.Seed;

public static class FakeProductGenerator
{
    public static List<Product> GenerateProductList(int count = 20)
    {
        var categories = new[] { "Категория 1", "Категория 2", "Категория 3" };
        var specialTags = new[] { "Новинка", "Популярный", "Рекомендуемый" };

        return new Faker<Product>("ru")
            .RuleFor(p => p.Id, f => f.IndexFaker + 1)
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Lorem.Sentence())
            .RuleFor(p => p.Category, f => f.PickRandom(categories))
            .RuleFor(p => p.SpecialTag, f => f.PickRandom(specialTags))
            .RuleFor(p => p.Price, f => Math.Round(f.Random.Decimal(1, 1000), 2))
            .RuleFor(p => p.Image, f => "https://devtool.tech/api/placeholder/200/200")
            .Generate(count);
    }
}
