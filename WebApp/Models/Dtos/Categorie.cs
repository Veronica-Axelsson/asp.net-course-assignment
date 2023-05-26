using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Dtos;

public class Categorie
{
    [Key]
    public int Id { get; set; }
    public string TagName { get; set; } = null!;
}
