using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        #region constructors & private fields

        private readonly UserService _userService;

        public AdminController(UserService userService)
        {
            _userService = userService;
        }

        #endregion


        public async Task<IActionResult> Index()
        {
            var viewModel = new UsersViewModel()
            {
                Users = await _userService.GetAllAsync()
            };
            return View(viewModel);
        }
    }
}
