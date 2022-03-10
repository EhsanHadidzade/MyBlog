using Microsoft.AspNetCore.Http;

namespace MyBlog.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetAll();
        void Create(CreateArticle create,IFormFile image);
        EditArticle GetArticleForEdit(long id);
        void Edit(EditArticle edit);
    }
}
