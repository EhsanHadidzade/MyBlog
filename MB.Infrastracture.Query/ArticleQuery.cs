using Microsoft.EntityFrameworkCore;
using MyBlog.Infrastructure.EFCore;

namespace MB.Infrastracture.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MyBlogContext _context;

        public ArticleQuery(MyBlogContext context)
        {
            _context = context;
        }

        public ArticleQueryView GetArticle(long id)
        {
            return _context.Articles.Select(x => new ArticleQueryView()
            {
                ArticleCategory = x.ArticleCategory.Title,
                Title = x.Title,
                CreationDate = x.CreationDate.ToString(),
                Id = x.Id,
                ShortDescription = x.ShortDescription,
                Image = x.Image,
                Content = x.Content
            }).FirstOrDefault(x=>x.Id==id);
        }

        public List<ArticleQueryView> GetArticles()
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView()
            {
                ArticleCategory = x.ArticleCategory.Title,
                Title = x.Title,
                CreationDate = x.CreationDate.ToString(),
                Id = x.Id,
                ShortDescription = x.ShortDescription,
                Image=x.Image
            }).ToList();
        }
    }
}
