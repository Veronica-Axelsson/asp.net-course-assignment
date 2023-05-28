using WebApp.Models.Dtos;

namespace WebApp.Models.Entities;

public class NewsletterEntity
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;


    public static implicit operator Newsletter(NewsletterEntity entity)
    {
        return new Newsletter
        {
            Id = entity.Id,
            Email = entity.Email
        };
    }

}
