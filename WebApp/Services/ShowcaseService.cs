using WebApp.Models;

namespace WebApp.Services;

public class ShowcaseService
{
    private readonly List<ShowcaseModel> _showcases = new()
    {
            new ShowcaseModel()
    {
        Ingress = "WELCOME TO BMERKETO SHOP",
        Title = "Exclusive Striped T-shirt.",
        ImageUrl = "images/products/c73055ef-c7fd-48e8-97c7-d3c74b2fcd26_BC270x295_StripedT-Shirt.jpg",
        Button = new LinkButtonModel
        {
            Content = "SHOP NOW",
            Url = "/products",
        }
     },
    };


    public ShowcaseModel GetLatest()
    {
        return _showcases.LastOrDefault()!;
    }

}
