using System.ComponentModel.DataAnnotations;
using WebApp.Models.Dtos;

namespace WebApp.Models.Entities
{
    public class ContactEntity
    {
        [Key]
        public Guid ContactId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNr { get; set; }
        public string? Company { get; set; }
        public string Description { get; set; } = null!;



        public static implicit operator Contact(ContactEntity entity)
        {
            return new Contact
            {
                ContactId = entity.ContactId,
                Name = entity.Name,
                Email = entity.Email,
                PhoneNr = entity.PhoneNr,
                Company = entity.Company,
                Description = entity.Description
            };
        }
    }
}
