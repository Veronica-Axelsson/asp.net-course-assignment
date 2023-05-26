using WebApp.Context;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories;

public class ContactRepository : Repo<ContactEntity>
{
    public ContactRepository(DataContext context) : base(context)
    {
    }
}
