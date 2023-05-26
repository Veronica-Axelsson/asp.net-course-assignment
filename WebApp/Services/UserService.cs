using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Context;
using WebApp.Helpers.Repositories;
using WebApp.Models.Dtos;

namespace WebApp.Services;
// Service, userRoleservice get users with roles, user manager. tolist, getroles, isinroleasync, addotoroleasync
public class UserService
{
    private readonly UserRepository _userRepository;
    private readonly IdentityContext _identityContext;
    private readonly UserManager<IdentityUser> _userManager;
    //private readonly UserRoleRepository _roleRepository;


    public UserService(IdentityContext identityContext, UserManager<IdentityUser> userManager, UserRepository userRepository/*, UserRoleRepository roleRepository*/)
    {
        _identityContext = identityContext;
        _userRepository = userRepository;
        //_roleRepository = roleRepository;
        _userManager = userManager;
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

    //public async Task<UserProfileEntity> GetUserProfileAsync(string userId)
    //{
    //    var userProfileEntity = await _identityContext.UserProfiles.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId == userId);
    //    return userProfileEntity!;
    //}


    //public async Task<UserProfile> CreateAsync(UserProfileEntity entity)
    //{
    //    var _entity = await _userRepository.GetAsync(x => x.UserId == entity.UserId);
    //    if (_entity == null)
    //    {
    //        _entity = await _userRepository.AddAsync(entity);
    //        if (_entity != null)
    //            return entity;
    //    }

    //    return entity;
    //}


    //public async Task AddProductTagsAsync(ProductEntity entity, string[] tags)
    //{
    //    foreach (var tag in tags)
    //    {
    //        await _userRepository.AddAsync(new ProductTagEntity
    //        {
    //            ArticleNumber = entity.ArticleNumber,
    //            TagId = int.Parse(tag)
    //        });
    //    }
    //}





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


                //model.UserId  = user.UserId;
                model.UserRole = user.UserRoles;
            };

            userList.Add(model);
        }


        return userList;







        //var users = await _us




        //var profiles = new List<UsersViewModel>();


        //var users = await _identityContext.UserProfiles
        //    .Include(x => x.User)
        //    .ToListAsync();

        //var roles = await _identityContext.UserRole
        //    .Include(x => x.Role)
        //    .ToListAsync();

        //foreach (var user in users)
        //{
        //    UsersViewModel viewModel = user;
        //    viewModel.Users. = await _userManager.GetRolesAsync(user.User);
        //}

        //// await _context.Products.Include(x => x.Category).ToListAsync()


        //return profiles;
    }










    //public async Task<IEnumerable<UsersViewModel>> GeattAllUserAsync()
    //{
    //    var profiles = new List<UsersViewModel>();


    //    var users = await _identityContext.UserProfiles
    //        .Include(x => x.User)
    //        .ToListAsync();

    //    var roles = await _identityContext.UserRole
    //        .Include(x => x.Role)
    //        .ToListAsync();

    //    foreach (var user in users) 
    //    {
    //        UsersViewModel viewModel = user;
    //        viewModel.Users. = await _userManager.GetRolesAsync(user.User);
    //    }

    //    // await _context.Products.Include(x => x.Category).ToListAsync()


    //    return profiles;
    //}


}
