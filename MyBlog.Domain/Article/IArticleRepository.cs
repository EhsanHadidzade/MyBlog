using _01_Framework.Infrastructure;
using MyBlog.Application.Contracts.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Article
{
    public interface IArticleRepository:IRepository<long,Article>
    {
        List<ArticleViewModel> GetList();
        //void Create(CreateArticle command);
        //Article Get(long id);
        void save();
    }
}
