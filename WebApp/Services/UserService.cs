using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Context;
using WebApp.Helpers.Repositories;
using WebApp.Models.Dtos;

namespace WebApp.Services;

public class UserService
{
    private readonly UserRepository _userRepository;
    private readonly IdentityContext _identityContext;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IWebHostEnvironment _webHostEnvironment;


    public UserService(IdentityContext identityContext, UserManager<IdentityUser> userManager, UserRepository userRepository, IWebHostEnvironment webHostEnvironment)
    {
        _identityContext = identityContext;
        _userRepository = userRepository;
        _userManager = userManager;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<IEnumerable<UserProfile>> GetUsersAndRolesAsync()
    {
        var users = new List<UserProfile>();
        foreach (var user in await _userManager.Users.ToListAsync())
        {
            var _user = new UserProfile
            {
                UserId = user.Id,
                FirstName = user.UserName!,
                Email = user.Email!,       
        };

            foreach (var role in await _userManager.GetRolesAsync(user))
            {
                _user.RoleNames.Add(role);
            }

            users.Add(_user);
        }

        return users;
    }



    public async Task<IEnumerable<UserProfile>> GetAllAsync()
    {
        var userList = new List<UserProfile>();
        var items = await _identityContext.UserProfiles.Include(x => x.UserRoles).ToListAsync();

        foreach (var user in items)
        {
            UserProfile model = new();
            {
                model.UserId = user.UserId;
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.StreetName = user.StreetName;
                model.PostalCode = user.PostalCode;
                model.City = user.City;
                model.Mobile = user.Mobile;
                model.Company = user.Company;

                model.UserRole = user.UserRoles;
            };

            userList.Add(model);
        }
        return userList;
    }

    public async Task<bool> UploadProfileImageAsync(UserProfile userImage, IFormFile image)
    {
        try
        {
            string imagePath = $"{_webHostEnvironment.WebRootPath}/images/profileImages/{userImage.UserImageUrl}";
            await image.CopyToAsync(new FileStream(imagePath, FileMode.Create));
            return true;
        }
        catch { return false; }
    }
}
