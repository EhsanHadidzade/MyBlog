using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBlog.Application.Contracts.ArticleCategory;

namespace MyBlog.Presentation.MVC.Areas.Administrator.Pages.ArticleCategory
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateArticleCategory ArticleCategory { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public CreateModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            
        }
        public RedirectToPageResult OnPost()
        {
            _articleCategoryApplication.Create(ArticleCategory);
            return RedirectToPage("./index");
        }
    }
}
