using _01_Framework.Infrastructure;
using MyBlog.Domain.ArticleCategory;

namespace MyBlog.Infrastructure.EFCore.Repositories
{
    public class ArticleCategoryRepository : BaseRepository<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly MyBlogContext _Context;

        public ArticleCategoryRepository(MyBlogContext context):base(context)
        {
            _Context = context;
        }

        public void save()
        {
            _Context.SaveChanges();
        }
    }
}
