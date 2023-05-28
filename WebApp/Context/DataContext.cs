using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;

namespace WebApp.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<NewsletterEntity> Newsletters { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductTagEntity> ProductTags { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
    }
}

