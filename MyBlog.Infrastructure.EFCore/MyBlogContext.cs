using Microsoft.EntityFrameworkCore;
using MyBlog.Domain.Article;
using MyBlog.Domain.ArticleCategory;
using MyBlog.Infrastructure.EFCore.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.EFCore
{
    public class MyBlogContext:DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }

        public MyBlogContext(DbContextOptions<MyBlogContext> options):base(options)    
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembply = typeof(ArticleCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembply);
            base.OnModelCreating(modelBuilder);
        }
    }
}
