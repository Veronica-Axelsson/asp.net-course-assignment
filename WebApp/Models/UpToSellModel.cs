namespace WebApp.Models;

public class UpToSellModel
{
    public CardModel CardLeft { get; set; } = null!;
    public string? TitleRed { get; set; }
    public string? Title { get; set; }
    public string? Ingress { get; set; }
    public string? Text { get; set; }
    public LinkButtonModel? ButtonMore { get; set; }
    public CardModel CardRight { get; set; } = null!;
}
