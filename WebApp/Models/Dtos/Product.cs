using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.Models.Dtos;

public class Product
{
    [Key]
    public string ArticleNumber { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? ImageUrl { get; set; } = null!;
    public string Price { get; set; } = null!;
    public string? OfferPrice { get; set; }
    public string Description { get; set; } = null!;
    public string? Category { get; set; }


    public ICollection<ProductTagEntity> Tags { get; set; } = new HashSet<ProductTagEntity>();
}
