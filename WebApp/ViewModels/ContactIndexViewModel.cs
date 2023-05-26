using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels;

public class ContactIndexViewModel
{
    [Display(Name = "Name*")]
    [Required(ErrorMessage = "You must enter your name")]
    [StringLength(50, MinimumLength = 3)]
    [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "You must enter your name")]
    public string Name { get; set; } = null!;


    //RFC 6531 standard för hur email får se ut
    [Display(Name = "Email*")]
    [Required(ErrorMessage = "You must enter a valid email adress")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]{2,}$", ErrorMessage = "You must enter a valid email adress")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;


    [Display(Name = "Phone number (optional)")]
    public string? PhoneNr { get; set; }


    [Display(Name = "Company (optional)")]
    public string? Company { get; set; }


    [Required(ErrorMessage = "You must write something")]
    [StringLength(500, MinimumLength = 3)]

    [Display(Name = "Message *")]
    public string Description { get; set; } = null!;


    public static implicit operator ContactEntity(ContactIndexViewModel viewModel)
    {
        var entity = new ContactEntity
        {
            Name = viewModel.Name,
            Email = viewModel.Email,
            PhoneNr = viewModel.PhoneNr,
            Company = viewModel.Company,
            Description = viewModel.Description
        };

        return entity;
    }
}
