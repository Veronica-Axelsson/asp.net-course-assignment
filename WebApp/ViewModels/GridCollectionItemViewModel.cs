using System.ComponentModel.DataAnnotations;
using WebApp.Models.Dtos;
using WebApp.Models.Entities;

namespace WebApp.ViewModels;

public class GridCollectionItemViewModel
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

    public IEnumerable<Categorie> Categories { get; set; } = new List<Categorie>();

    public IEnumerable<Product> Products { get; set; } = new List<Product>();

    public IEnumerable<Newsletter> Newsletters { get; set; } = new List<Newsletter>();
}
