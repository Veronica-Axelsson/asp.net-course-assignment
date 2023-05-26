﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.Models.Dtos;

public class UserProfile
{
    [Key/*, ForeignKey(nameof(User))*/]
    public string UserId { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public string? Mobile { get; set; }
    public string? Company { get; set; }


    public List<string> RoleNames { get; set; } = new List<string>();


    public ICollection<UserRoleEntity> UserRole { get; set; } = new HashSet<UserRoleEntity>();


    //Koppla denna till tabell eller något?
    //public string Role { get; set; } = null!;
    //public List<string> Role = new();


    //public IdentityUser User { get; set; } = null!;
}
