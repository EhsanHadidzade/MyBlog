using _01_Framework.Infrastructure;
using MyBlog.Application.Contracts.ArticleCategory;
using MyBlog.Domain.ArticleCategory;
using MyBlog.Domain.Services;

namespace MyBlog.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _validatorService;
        private readonly IUnitOfWork _unitOfWork;



        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService validatorService, IUnitOfWork unitOfWork)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _validatorService = validatorService;
            _unitOfWork = unitOfWork;
        }

        public void Create(CreateArticleCategory command)
        {
            _unitOfWork.BeginTran();
            var articlecategory=new ArticleCategory(command.Title, _validatorService);
            //_articleCategoryRepository.Add(articlecategory);
            _articleCategoryRepository.Create(articlecategory);
            _unitOfWork.CommitTran();
            //_articleCategoryRepository.save();
        }

        public void Delete(long id)
        {
            _unitOfWork.BeginTran();
            var articlecategory = _articleCategoryRepository.Get(id);
            articlecategory.Delete();
            _unitOfWork.CommitTran();
            //_articleCategoryRepository.save();

        }

        public void Edit(EditArticleCategory command)
        {
            var articlecategory = _articleCategoryRepository.Get(command.Id);
            articlecategory.Rename(command.Title);
            _articleCategoryRepository.save();
            
        }

        public EditArticleCategory Get(int id)
        {
            var articlecategory = _articleCategoryRepository.Get(id);
            var result = new EditArticleCategory()
            {
                Id = articlecategory.Id,
                Title = articlecategory.Title,
            };
            return result;
        }

        public List<ArticleCategoryViewModel> GetList()
        {
           var articlecategories=_articleCategoryRepository.GetAll();
            var result = new List<ArticleCategoryViewModel>();
            foreach (var articlecategory in articlecategories)
            {
                result.Add(new ArticleCategoryViewModel()
                {
                    Id = articlecategory.Id,
                    Title = articlecategory.Title,
                    CreationDate = articlecategory.CreationDate.ToString(),
                    IsDeleted = articlecategory.IsDeleted,
                });
            }
            return result;
        }

        public void Restore(long id)
        {
            _unitOfWork.BeginTran();
            var articlecategory = _articleCategoryRepository.Get(id);
            articlecategory.Restore();
            _unitOfWork.CommitTran();
            //_articleCategoryRepository.save();

        }
    }
}
