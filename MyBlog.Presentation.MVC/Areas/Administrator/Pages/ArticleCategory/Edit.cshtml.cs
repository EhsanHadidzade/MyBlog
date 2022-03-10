using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBlog.Application.Contracts.ArticleCategory;

namespace MyBlog.Presentation.MVC.Areas.Administrator.Pages.ArticleCategory
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditArticleCategory ArticleCategory { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }
        public void OnGet(int id)
        {
            ArticleCategory = _articleCategoryApplication.Get(id);
        }
        public RedirectToPageResult OnPost()
        {
            _articleCategoryApplication.Edit(ArticleCategory);
            return RedirectToPage("./index");
        }
        
    }
}
