using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBlog.Application.Contracts.ArticleCategory;

namespace MyBlog.Presentation.MVC.Areas.Administrator.Pages.ArticleCategory
{
    public class IndexModel : PageModel
    {
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            ArticleCategories = _articleCategoryApplication.GetList();
        }
        public RedirectToPageResult OnGetRestore(int id)
        {
            _articleCategoryApplication.Restore(id);
            return RedirectToPage("./index");
            
        }
       
        public RedirectToPageResult OnGetDelete(int id)
        {
            _articleCategoryApplication.Delete(id);
            return RedirectToPage("./index");
        }

    }
}
