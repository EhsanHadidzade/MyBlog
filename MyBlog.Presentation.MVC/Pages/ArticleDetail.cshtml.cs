using MB.Infrastracture.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyBlog.Presentation.MVC.Pages
{
    public class ArticleDetailModel : PageModel
    {

        public ArticleQueryView Article { get; set; }
        private IArticleQuery _articleQuery;
        public ArticleDetailModel(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public void OnGet(long id)
        {
           Article= _articleQuery.GetArticle(id);
        }
    }
}
