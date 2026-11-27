using System.ComponentModel.DataAnnotations;

namespace Api.ModelDto;

public class ProductCreateDto
{
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Description { get; set; }
    public string? SpecialTag { get; set; }
    public string? Category { get; set; }
    [Range(1, 1000)]
    public required decimal Price { get; set; }
    public string? Image { get; set; }
}
