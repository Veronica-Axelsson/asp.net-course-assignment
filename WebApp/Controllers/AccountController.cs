using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Dtos;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AutService _auth;
        private readonly UserService _userService;

        public AccountController(AutService auth, UserService userService)
        {
            _auth = auth;
            _userService = userService;
        }


        [Authorize]
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserSignUpViewModel model)
        {
            var userprofile = new UserProfile();
            if (ModelState.IsValid)
            {
                if (await _auth.SignUpAsync(model))
                {
                    if (model.ProfileImg != null)
                        await _userService.UploadProfileImageAsync( userprofile, model.ProfileImg!);

                    return RedirectToAction("SignIn");

                }

                else 
                    ModelState.AddModelError("", "A user with the same email already exists");
            }

            return View(model);
        }


        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _auth.SignInAsync(model))
                    return RedirectToAction("Index");

                else
                    ModelState.AddModelError("", "Incorrect email or password");

            }

            return View(model);
        }



        [Authorize]
        public new async Task<IActionResult> SignOut()
        {
            if (await _auth.SignOutAsync(User))
                return LocalRedirect("/");


            return RedirectToAction("Index", "Home");
        }
    }
}
