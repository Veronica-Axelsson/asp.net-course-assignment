using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    #region constructors & private fields

    private readonly ProductService _productService;
    //private readonly TagService _tagService;

    public HomeController(ProductService productService/*, TagService tagService*/)
    {
        _productService = productService;
        //_tagService = tagService;
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
