﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Context;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories
{
    public class ProductRepository : Repo<ProductEntity>
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<ProductEntity>> GetAsync()
        {
            var products = await _context.Products.Include(x => x.ProductTags).ThenInclude(y => y.Tag).ToListAsync();
            return products;
        }

        public override async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            var product = await _context.Products.Include(x => x.ProductTags).ThenInclude(y => y.Tag).FirstOrDefaultAsync(expression);
            return product!;
        }
    }
}
