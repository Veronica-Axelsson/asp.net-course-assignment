using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ProductsPageController : Controller
{
    #region constructors & private fields

    private readonly ProductService _productService;

    public ProductsPageController(ProductService productService)
    {
        _productService = productService;
    }



    #endregion

    public async Task<IActionResult> Index()
    {
        var viewModel = new ProductCombinedViewModel()
        {
            Products = await _productService.GetAllAsync()
        };
        return View(viewModel);
    }

    public IActionResult Search()
    {
        ViewData["Title"] = "Search for products";
        return View();
    }
}
