using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels
{
    public class NewsletterViewModel
    {
        //RFC 6531 standard för hur email får se ut
        [Display(Name = "Email*")]
        [Required(ErrorMessage = "You must enter a valid email adress")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]{2,}$", ErrorMessage = "You must enter a valid email adress")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;


        public static implicit operator NewsletterEntity(NewsletterViewModel viewModel)
        {
            var entity = new NewsletterEntity
            {
                Email = viewModel.Email
            };

            return entity;
        }
    }
}
