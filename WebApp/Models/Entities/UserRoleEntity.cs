using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.Dtos;

namespace WebApp.Models.Entities
{
    public class UserRoleEntity
    {
        [Key]
        public int RoleId { get; set; }
        public string Role { get; set; } = null!;
    }
}
