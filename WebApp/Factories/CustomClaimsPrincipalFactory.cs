using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using WebApp.Models.Entities;
using WebApp.Services;

namespace WebApp.Factories
{
    public class CustomClaimsPrincipalFactory /*: UserClaimsPrincipalFactory<UserProfileEntity>*/
    {
        //private readonly UserManager<UserProfileEntity> userManager;
        //private readonly UserService _userService;

        //public CustomClaimsPrincipalFactory(UserManager<UserProfileEntity> userManager, IOptions<IdentityOptions> optionsAccessor, UserService userService) : base(userManager, optionsAccessor)
        //{
        //    this.userManager = userManager;
        //    _userService = userService;
        //}


        //protected override async Task<ClaimsIdentity> GenerateClaimsAsync(UserProfileEntity user)
        //{
        //    var claimsIdentity = await base.GenerateClaimsAsync(user);

        //    --//var identityUser = await userManager.FindByIdAsync(user.Id); Nytt


        //    --//var userProfileEntity = await _userService.GetUserProfileAsync(user.Id);

        //    claimsIdentity.AddClaim(new Claim("DisplayName", $"{user.FirstName} {user.LastName}"));



        //    return claimsIdentity;
        //}
    }

    //public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<IdentityUser>
    //{
    //    private readonly UserService _userService;

    //    public CustomClaimsPrincipalFactory(UserManager<IdentityUser> userManager, IOptions<IdentityOptions> optionsAccessor, UserService userService) : base(userManager, optionsAccessor)
    //    {
    //        _userService = userService;
    //    }

    //    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user)
    //    {
    //        var claimsIdentity = await base.GenerateClaimsAsync(user);

    //        var userProfileEntity = await _userService.GetUserProfileAsync(user.Id);

    //        claimsIdentity.AddClaim(new Claim("DisplayName", $"{userProfileEntity.FirstName} {userProfileEntity.LastName}"));

    //        // Remove the "admin" claim if present
    //        var adminClaim = claimsIdentity.FindFirst("admin");
    //        if (adminClaim != null)
    //        {
    //            claimsIdentity.RemoveClaim(adminClaim);
    //        }

    //        return claimsIdentity;
    //    }
    //}



}
