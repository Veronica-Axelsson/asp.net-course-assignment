namespace WebApp.Models
{
    public class CardModel
    {
        public string ImageUrl { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Price { get; set; } = null!;
        public string? OfferPrice { get; set; }
        //public string? AddToCart { get; set; }
    }
}
