using _01_Framework.Infrastructure;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Contracts.Article;
using MyBlog.Domain.Article;

namespace MyBlog.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleApplication(IArticleRepository articleRepository, IUnitOfWork unitOfWork)
        {
            _articleRepository = articleRepository;
            _unitOfWork = unitOfWork;
        }

        public void Create(CreateArticle create,IFormFile image)
        {
            _unitOfWork.BeginTran();
            create.Image = image.FileName;
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BlogImages", create.Image);
            using(var stream=new FileStream(filepath,FileMode.Create))
            {
                image.CopyTo(stream);
            }
            var article = new Article(create.Title, create.ShortDescription, create.Image,create.Content, create.ArticleCategoryId);
            _articleRepository.Create(article);
            _unitOfWork.CommitTran();
        }

        public void Edit(EditArticle edit)
        {
            _unitOfWork.BeginTran();
            var article=_articleRepository.Get(edit.Id);
            article.Edit(edit.Title, edit.ShortDescription, edit.Image, edit.Content, edit.ArticleCategoryId);
            _unitOfWork.CommitTran();
            //_articleRepository.save();
        }

        public List<ArticleViewModel> GetAll()
        {
            return _articleRepository.GetList();
        }

        public EditArticle GetArticleForEdit(long id)
        {
           var article=_articleRepository.Get(id);
            var result = new EditArticle()
            {
                Title = article.Title,
                ShortDescription = article.ShortDescription,
                Image = article.Image,
                Content = article.Content,
                ArticleCategoryId = article.ArticleCategoryId,
                Id = id

            };
            return result;
        }
    }
}
