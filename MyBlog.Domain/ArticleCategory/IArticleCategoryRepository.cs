using _01_Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.ArticleCategory
{
    public interface IArticleCategoryRepository:IRepository<long,ArticleCategory>
    {
        //List<ArticleCategory> GetAll();
        //void Create(ArticleCategory entity);
        void save();
        //ArticleCategory Get(long id);
        //bool IsExists(string title);
    }
}
