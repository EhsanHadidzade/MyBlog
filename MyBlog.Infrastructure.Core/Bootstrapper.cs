using _01_Framework.Infrastructure;
using MB.Infrastracture.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Application;
using MyBlog.Application.Contracts.Article;
using MyBlog.Application.Contracts.ArticleCategory;
using MyBlog.Domain.Article;
using MyBlog.Domain.ArticleCategory;
using MyBlog.Domain.Services;
using MyBlog.Infrastructure.EFCore;
using MyBlog.Infrastructure.EFCore.Repositories;

namespace MyBlog.Infrastructure.Core
{
    public class Bootstrapper
    {
        public static void Configuration(IServiceCollection services,string connectionstring)
        {
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryValidatorService,ArticleCategoryValidatorService>();


            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleApplication, ArticleApplication>();


            services.AddTransient<IArticleQuery, ArticleQuery>();

            services.AddTransient<IUnitOfWork,UnitOfWork>();

            



            services.AddDbContext<MyBlogContext>(options=>options.UseSqlServer(connectionstring));
        }
    }
}