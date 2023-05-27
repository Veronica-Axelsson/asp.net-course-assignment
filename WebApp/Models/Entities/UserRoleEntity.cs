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

        //public ICollection<UserRoleEntity> UserRoles { get; set; } = new HashSet<UserRoleEntity>();


        //public static implicit operator UserRole(UserRoleEntity entity)
        //{
        //    return new UserRole
        //    {
        //        RoleId = entity.RoleId,
        //        Role = entity.Role
        //    };
        //}


    }
}
