using WebApp.Context;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories
{
    public class NewsletterRepository : Repo<NewsletterEntity>
    {
        public NewsletterRepository(DataContext context) : base(context)
        {
        }
    }
}
 