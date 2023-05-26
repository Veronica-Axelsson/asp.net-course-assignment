using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Dtos;
using WebApp.Models.Entities;

namespace WebApp.Services;

public class UserAdminServices
{
    //private readonly UserManager<UserProfileEntity> _userManager;

    //public UserAdminServices(UserManager<UserProfileEntity> userManager)
    //{
    //    _userManager = userManager;
    //}

    //public async Task<IEnumerable<UserProfile>> GetUsersAndRolesAsync()
    //{
    //    var users = new List<UserProfile>();
    //    foreach( var user in await _userManager.Users.ToListAsync())
    //    {
    //        var _user = new UserProfile
    //        {
    //            UserId = user.UserId,
    //            FirstName = user.FirstName,
    //            LastName = user.LastName,
    //            Email = user.Email,
    //            StreetName = user.StreetName,
    //            PostalCode = user.PostalCode,
    //            City = user.City,
    //            Mobile = user.Mobile,
    //            Company = user.Company                
    //        };

    //        foreach(var role in await _userManager.GetRolesAsync(user))
    //        {
    //            _user.RoleNames.Add(role);
    //        }

    //        users.Add(_user);
    //    }

    //    return users;
    //}
}
