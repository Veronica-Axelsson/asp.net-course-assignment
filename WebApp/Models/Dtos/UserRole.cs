using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Dtos;

public class UserRole
{
    [Key]
    public string RoleId { get; set; } = null!;
    public string Role { get; set; } = null!;
}
