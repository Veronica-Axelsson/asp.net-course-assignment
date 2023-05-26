using WebApp.Models;
using WebApp.Views.Partials;

namespace WebApp.Services
{
    public class UpToSellService
    {
        private readonly List<UpToSellModel> _upToSell = new()
    {
    new UpToSellModel()
    {
        CardLeft = new CardModel()
        {
            ImageUrl = "images/placeholders/369x310.svg",
            Title = "1. Table Lamp - scelerisque tempore",
            Price = "$50.00",
            OfferPrice = "$30,00",
            //AddToCart = "class=\"add-cart fa-regular fa-cart-plus"
        },

       TitleRed = "UP TO SELL",
       Title = "50% OFF",
       Ingress = "Get The Best Price",
       Text = "Get the best daily offer et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren no sea taki",

        ButtonMore = new LinkButtonModel
        {
            Url = "/products",
            Content = "Discover More",

        },

        CardRight = new CardModel()
        {
            ImageUrl = "images/placeholders/369x310.svg",
            Title = "2. Table Lamp - scelerisque tempore",
            Price = "$50.00",
            OfferPrice = "$30,00",
            //AddToCart = "class=\"add-cart fa-regular fa-cart-plus"
        },
    }
};


        public UpToSellModel GetLatest()
        {
            return _upToSell.LastOrDefault()!;
        }
    }
}
