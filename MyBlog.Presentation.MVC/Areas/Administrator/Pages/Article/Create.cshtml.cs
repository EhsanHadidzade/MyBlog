using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.Application.Contracts.Article;
using MyBlog.Application.Contracts.ArticleCategory;

namespace MyBlog.Presentation.MVC.Areas.Administrator.Pages.Article
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateArticle Article { get; set; }
        public List<SelectListItem> ArticleCategories { get; set; }
        private IArticleCategoryApplication _articleCategoryApplication;
        private IArticleApplication _articleApplication;

        public CreateModel(IArticleCategoryApplication articleCategoryApplication, IArticleApplication articleApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
            
            ArticleCategories=_articleCategoryApplication.GetList().Select(x=>new SelectListItem() { Text=x.Title,Value=x.Id.ToString()}).ToList();
        }
        public RedirectToPageResult OnPost(IFormFile image)
        {
            
            _articleApplication.Create(Article,image);
            return RedirectToPage("./index");
        }
    }
}
