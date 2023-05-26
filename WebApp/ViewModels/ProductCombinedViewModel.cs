using WebApp.Models.Dtos;

namespace WebApp.ViewModels;

public class ProductCombinedViewModel
{
    public IEnumerable<Categorie> Categories { get; set; } = new List<Categorie>();

    public IEnumerable<Product> Products { get; set; } = new List<Product>();
}
