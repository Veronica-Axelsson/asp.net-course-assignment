using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    #region constructors & private fields

    private readonly ProductService _productService;

    public HomeController(ProductService productService)
    {
        _productService = productService;
    }

    #endregion


    public async Task<IActionResult> Index()
    {
        
            var viewModel = new GridCollectionItemViewModel()
            {
                Products = await _productService.GetAllAsync()
            };
            return View(viewModel);
        
    }

    public IActionResult Details(string id)
    {

        return View(id);
    }
}
