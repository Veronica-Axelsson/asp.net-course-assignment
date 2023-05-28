using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class ProductDetailsController : Controller
{
    public IActionResult Index()
    {

        return View();
    }

    public IActionResult Details(int id)
    {

        return View(id);
    }
}
