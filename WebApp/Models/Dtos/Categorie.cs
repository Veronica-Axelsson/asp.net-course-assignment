using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Dtos;

public class Categorie
{
    [Key]
    public string Id { get; set; } = null!;
    public string TagName { get; set; } = null!;
}
