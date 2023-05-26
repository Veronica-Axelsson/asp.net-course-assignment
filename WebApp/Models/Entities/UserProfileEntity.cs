using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Models.Entities;

public class UserProfileEntity
{
    [Key, ForeignKey(nameof(User))]
    public string UserId { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public string? Mobile { get; set; }
    public string? Company { get; set; }


    public IdentityUser User { get; set; } = null!;

    public ICollection<UserRoleEntity> UserRoles { get; set; } = new HashSet<UserRoleEntity>();

}
