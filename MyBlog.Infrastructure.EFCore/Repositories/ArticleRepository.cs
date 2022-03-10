using _01_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Contracts.Article;
using MyBlog.Domain.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.EFCore.Repositories
{
    public class ArticleRepository : BaseRepository<long,Article>, IArticleRepository
    {
        private MyBlogContext _context;

        public ArticleRepository(MyBlogContext context):base(context)
        {
            _context = context;
        }

        public List<ArticleViewModel> GetList()
        {
            return _context.Articles.Include(x=>x.ArticleCategory).Select(x => new ArticleViewModel()
            {
                Title = x.Title,
                Id = x.Id,
                CreationDate = x.CreationDate.ToString(),
                ArticleCategory = x.ArticleCategory.Title,
                IsDeleted=x.IsDeleted
            }).ToList();
        }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}
