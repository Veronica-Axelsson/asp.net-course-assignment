using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Context;
using WebApp.Models.Dtos;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ProductDetailsController : Controller
{
    #region constructors & private fields

    private readonly ProductDetailsService _productDetailsService;
    private readonly DataContext _dataContext;


    public ProductDetailsController(ProductDetailsService productDetailsService, DataContext dataContext)
    {
        _productDetailsService = productDetailsService;
        _dataContext = dataContext;
    }

    #endregion

    public IActionResult Index()
    {

        return View();
    }

    public IActionResult Details(string articleNumber)
    {

        return View(articleNumber);
    }


    //public async Task<IActionResult> Index(string articleNumber)
    //{
    //    var product = await _productDetailsService.GetProductById(articleNumber);

    //    if (product == null)
    //    {
    //        return NotFound();
    //    }
    //    else
    //    {

    //    }

    //    return View(product);
    //}




    //public /*async Task<*/IActionResult/*>*/ Index(string _articleNumber)
    //{
    //    var viewModel = new GridCollectionItemViewModel()
    //    {
    //        //Products = await _productDetailsService.GetProductById(_articleNumber)
    //    };
    //    return View(viewModel);
    //}

}
