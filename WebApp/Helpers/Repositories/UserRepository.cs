using WebApp.Context;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories
{
    public class UserRepository : RepoIdentity<UserProfileEntity>
    {
        public UserRepository(IdentityContext context) : base(context)
        {
        }
    }
}
