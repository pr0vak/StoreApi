using System.ComponentModel.DataAnnotations;

namespace Api.Models;

public class ProductCreateDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public string SpecialTag { get; set; }
    public string Category { get; set; }
    [Range(1, 1000)]
    public decimal Price { get; set; }
    public string Image { get; set; }
}
