using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ProductBackofficeController : Controller
{
    #region constructors & private fields

    private readonly ProductService _productService;
    private readonly TagService _tagService;

    public ProductBackofficeController(ProductService productService, TagService tagService)
    {
        _productService = productService;
        _tagService = tagService;
    }

    #endregion



    public async Task<IActionResult> Index()
    {
        var viewModel = new ProductsViewModel()
        {
            Products = await _productService.GetAllAsync()
        };
        return View(viewModel);
    }

    public async Task<IActionResult> Register()
    {
        ViewBag.Tags = await _tagService.GetTagsAsync();

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(ProductRegistrationViewModel viewModel, string[] tags)
    {
        var product = await _productService.CreateAsync(viewModel);

        if (ModelState.IsValid)
        {
            //Create product
            if (product != null)
            {
                await _productService.AddProductTagsAsync(viewModel, tags); //Add Tags to ProductTags

            }

            if (product != null)
            {
                if (viewModel.ProductImage != null)
                    await _productService.UploadImageAsync(product, viewModel.ProductImage!);

                return RedirectToAction("Index");
            }


            ModelState.AddModelError("", "Something went wrong when creating a product");
        }

        ViewBag.Tags = await _tagService.GetTagsAsync(tags);
        return View(viewModel);
    }


}
