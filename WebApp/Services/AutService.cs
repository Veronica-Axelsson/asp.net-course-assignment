using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApp.Context;
using WebApp.Models.Entities;
using WebApp.ViewModels;

namespace WebApp.Services;

public class AutService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    private readonly IdentityContext _identityContext;
    private readonly SeedService _seedService;

    public AutService(UserManager<IdentityUser> userManager, IdentityContext identityContext, SignInManager<IdentityUser> signInManager, SeedService seedService)
    {
        _userManager = userManager;
        _identityContext = identityContext;
        _signInManager = signInManager;
        _seedService = seedService;
    }



    public async Task<bool> SignUpAsync(UserSignUpViewModel model)
    {
        try
        {
            await _seedService.SeedRoles();
            var roleName = "user";

            if (!await _userManager.Users.AnyAsync())
                roleName = "admin";

            IdentityUser identityUser = model;
            await _userManager.CreateAsync(identityUser, model.Password);

            await _userManager.AddToRoleAsync(identityUser, roleName);

            UserProfileEntity userProfileEntity = model;
            userProfileEntity.UserId = identityUser.Id;

            _identityContext.UserProfiles.Add(userProfileEntity);
            await _identityContext.SaveChangesAsync();

            return true;
        }
        catch { return false; }
    }


    public async Task<bool> SignInAsync(UserSignInViewModel model)
    {
        try
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            return result.Succeeded;
        }
        catch { return false; }
    }

    public async Task<bool> SignOutAsync(ClaimsPrincipal user)
    {
        await _signInManager.SignOutAsync();

        return _signInManager.IsSignedIn(user);
    }
}
