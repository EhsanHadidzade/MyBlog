using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        void Create(CreateArticleCategory command);
        void Edit(EditArticleCategory command);
        EditArticleCategory Get(int id);
        List<ArticleCategoryViewModel> GetList();
        void Delete(long id);
        void Restore(long id);
    }
}
