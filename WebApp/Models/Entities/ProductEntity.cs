using System.ComponentModel.DataAnnotations;
using WebApp.Models.Dtos;

namespace WebApp.Models.Entities;

public class ProductEntity
{
    [Key]
    public string ArticleNumber { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? ImageUrl { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Price { get; set; } = null!;

    public string? OfferPrice { get; set; }

    public string? Category { get; set; }


    public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();



    public static implicit operator Product(ProductEntity entity)
    {
        return new Product
        {
            ArticleNumber = entity.ArticleNumber,
            ImageUrl = entity.ImageUrl,
            Name = entity.Name,
            Price = entity.Price,
            OfferPrice = entity.OfferPrice,
            Description = entity.Description

        };
    }
}
