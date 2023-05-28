using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels;

public class UserSignUpViewModel
{
    [Display(Name = "First name*")]
    [Required(ErrorMessage = "You must enter your first name")]
    [StringLength(50, MinimumLength = 3)]
    [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "You must enter your first name")]
    public string FirstName { get; set; } = null!;


    [Display(Name = "Last name*")]
    [Required(ErrorMessage = "You must enter your last name")]
    [StringLength(50, MinimumLength = 3)]
    [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "You must enter your last name")]
    public string LastName { get; set; } = null!;


    [Display(Name = "Street name*")]
    [Required(ErrorMessage = "You must enter your street name")]
    [StringLength(50, MinimumLength = 3)]
    public string StreetName { get; set; } = null!;


    [Display(Name = "Postal Code*")]
    [Required(ErrorMessage = "You must enter your postal Code")]
    [StringLength(15, MinimumLength = 3)]
    public string PostalCode { get; set; } = null!;



    [Display(Name = "City*")]
    [Required(ErrorMessage = "You must enter a city")]
    [StringLength(150, MinimumLength = 3)]
    [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "You must enter a city")]
    public string City { get; set; } = null!;


    [Display(Name = "Mobile (optional)")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Company (optional)")]
    public string? Company { get; set; }


    //RFC 6531 standard för hur email får se ut
    [Display(Name = "Email*")]
    [Required(ErrorMessage = "You must enter a valid email adress")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]{2,}$", ErrorMessage = "You must enter a valid email adress")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;


    [Required(ErrorMessage = "You must enter a password")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "You must enter a password")]
    [Display(Name = "Password*")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;



    [Required(ErrorMessage = "You must confirm the password")]
    [Compare(nameof(Password), ErrorMessage = "Password don't match")]
    [Display(Name = "Confirm the password*")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;


    [DataType(DataType.Upload)]
    public IFormFile? ProfileImg { get; set; }


    


    public static implicit operator IdentityUser(UserSignUpViewModel model)
    {
        return new IdentityUser
        {
            // Gui Id skapas automatiskt
            UserName = model.Email,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,

        };
    }

    public static implicit operator UserProfileEntity(UserSignUpViewModel model)
    {
        var entity = new UserProfileEntity
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            StreetName = model.StreetName,
            PostalCode = model.PostalCode,
            City = model.City,
            Mobile = model.PhoneNumber,
            Company = model.Company,

        };

        if (model.ProfileImg != null)
        {
            entity.UserImageUrl = $"{Guid.NewGuid()}_{model.ProfileImg?.FileName}";
        }

        return entity;
    }
}
