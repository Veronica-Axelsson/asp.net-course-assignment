using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels;

public class ProductRegistrationViewModel
{
    public string ArticleNumber { get; set; } = null!;


    [Required(ErrorMessage = "You must enter the products name")]
    [Display(Name = "Products name *")]
    public string Name { get; set; } = null!;


    [Required(ErrorMessage = "You must upload an image")]
    [Display(Name = "Upload a image *")]
    [DataType(DataType.Upload)]
    public IFormFile? ProductImage { get; set; }


    [Required(ErrorMessage = "You must enter the products price")]
    [Display(Name = "Products price *")]
    [DataType(DataType.Currency)]
    public string Price { get; set; } = null!;


    [Display(Name = "Products offer price *")]
    [DataType(DataType.Currency)]
    public string? OfferPrice { get; set; }


    [Required(ErrorMessage = "You must enter the products description")]
    [Display(Name = "Products description *")]
    public string Description { get; set; } = null!;




    public static implicit operator ProductEntity(ProductRegistrationViewModel viewModel)
    {
        var entity = new ProductEntity
        {
            ArticleNumber = viewModel.ArticleNumber,
            Name = viewModel.Name,
            Price = viewModel.Price,
            OfferPrice = viewModel.OfferPrice,
            Description = viewModel.Description,
        };

        if (viewModel.ProductImage != null)
        {
            entity.ImageUrl = $"{Guid.NewGuid()}_{viewModel.ProductImage?.FileName}";
        }

        return entity;
    }
}
