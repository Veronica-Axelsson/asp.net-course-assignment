using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels;

public class UserSignInViewModel
{
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

    public bool RememberMe { get; set; }
}
