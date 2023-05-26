using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Dtos;

public class Contact
{
    [Key]
    public Guid ContactId { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNr { get; set; }
    public string? Company { get; set; }
    public string Description { get; set; } = null!;
}
