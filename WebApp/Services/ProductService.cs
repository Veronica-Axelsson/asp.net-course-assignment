using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Context;
using WebApp.Helpers.Repositories;
using WebApp.Models.Dtos;
using WebApp.Models.Entities;
using WebApp.ViewModels;

namespace WebApp.Services;

public class ProductService
{
    #region constructors & private fields

    private readonly ProductRepository _productRepo;
    private readonly ProductTagRepository _productTagRepo;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly DataContext _dataContext;

    public ProductService(ProductRepository productRepo, ProductTagRepository productTagRepo, IWebHostEnvironment webHostEnvironment, DataContext dataContext)
    {
        _productRepo = productRepo;
        _productTagRepo = productTagRepo;
        _webHostEnvironment = webHostEnvironment;
        _dataContext = dataContext;
    }

    #endregion


    public async Task<Product> CreateAsync(ProductEntity entity)
    {
        var _entity = await _productRepo.GetAsync(x => x.ArticleNumber == entity.ArticleNumber);
        if (_entity == null)
        {
            _entity = await _productRepo.AddAsync(entity);
            if (_entity != null)
                return entity;
        }

        return entity;
    }



    //public async Task<GridCollectionItemViewModel> GetProductById(string articleNumber)
    //{
    //    var _product = await _productRepo.GetAsync(x => x.ArticleNumber == articleNumber);


    //    var viewModel = new GridCollectionItemViewModel
    //    {
    
    //    };
   
    //        return viewModel;
    //}
        
    //public async Task<List<SelectListItem>> GetTagsAsync()
    //{
    //    var tags = new List<SelectListItem>();

    //    foreach (var tag in await _tagRepo.GetAllAsync())
    //    {
    //        tags.Add(new SelectListItem
    //        {
    //            Value = tag.Id.ToString(),
    //            Text = tag.TagName
    //        });
    //    }

    //    return tags;
    //}














    public async Task AddProductTagsAsync(ProductEntity entity, string[] tags)
    {
        foreach (var tag in tags)
        {
            await _productTagRepo.AddAsync(new ProductTagEntity
            {
                ArticleNumber = entity.ArticleNumber,
                TagId = int.Parse(tag)
            });
        }
    }


    public async Task<bool> UploadImageAsync(Product product, IFormFile image)
    {
        try
        {
            string imagePath = $"{_webHostEnvironment.WebRootPath}/images/products/{product.ImageUrl}";
            await image.CopyToAsync(new FileStream(imagePath, FileMode.Create));
            return true;
        }
        catch { return false; }
    }




    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var productList = new List<Product>();
        var items = await _dataContext.Products.Include(x => x.ProductTags).ThenInclude(j => j.Tag).ToListAsync();

        foreach (var item in items)
        {
            Product model = new();
            {
                model.ImageUrl = item.ImageUrl;
                model.ArticleNumber = item.ArticleNumber;
                model.Name = item.Name;
                model.Price = item.Price;
                model.Category = item.Category;
                model.OfferPrice = item.OfferPrice;
                model.Description = item.Description;

                model.Tags = item.ProductTags;

            };

            productList.Add(model);
        }


        return productList;
    }



}
