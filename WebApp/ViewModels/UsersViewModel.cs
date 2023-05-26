using WebApp.Models.Dtos;

namespace WebApp.ViewModels
{
    public class UsersViewModel
    {
        public IEnumerable<UserProfile> Users { get; set; } = new List<UserProfile>();

    }
}
