using WebApp.Models.Dtos;

namespace WebApp.ViewModels;

public class GridCollectionViewModel
{
    public string Title { get; set; } = "";
    //public IEnumerable<string> Categories { get; set; } = null!;
    public IEnumerable<GridCollectionItemViewModel> GridItems { get; set; } = null!;
    public bool LoadMore { get; set; } = false;

    //public IEnumerable<Categorie> Categories { get; set; } = new List<Categorie>();

    //public IEnumerable<Product> Products { get; set; } = new List<Product>();


}
