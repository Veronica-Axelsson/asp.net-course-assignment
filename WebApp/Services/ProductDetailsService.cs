using WebApp.Context;
using WebApp.Helpers.Repositories;
using WebApp.Models.Dtos;
using WebApp.ViewModels;

namespace WebApp.Services;

public class ProductDetailsService
{
    #region constructors & private fields

    private readonly ProductRepository _productRepo;

    public ProductDetailsService(ProductRepository productRepo)
    {
        _productRepo = productRepo;
    }

    //private readonly ProductTagRepository _productTagRepo;
    //private readonly IWebHostEnvironment _webHostEnvironment;
    //private readonly DataContext _dataContext;

    #endregion


    public async Task<GridCollectionItemViewModel> GetProductById(string articleNumber)
    {
        var _product = await _productRepo.GetAsync(x => x.ArticleNumber == articleNumber);

        if(_product != null) 
        {
            GridCollectionItemViewModel viewModel = new()
            {
                ArticleNumber = articleNumber,
                Name = _product.Name,
                ImageUrl = _product.ImageUrl,
                Price = _product.Price,
                OfferPrice = _product.OfferPrice,
                Description = _product.Description,
                Category = _product.Category,
            };
            return viewModel;

        }
        else
        {
            return NotFound();
        }


    
    }

    private GridCollectionItemViewModel NotFound()
    {
        throw new NotImplementedException();
    }
}
