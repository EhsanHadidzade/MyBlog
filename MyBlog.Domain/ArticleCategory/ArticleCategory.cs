using _01_Framework.Domain;
using MyBlog.Domain.Exceptions;
using MyBlog.Domain.Services;

namespace MyBlog.Domain.ArticleCategory
{
    public class ArticleCategory:DomainBase<long>
    {
        //public long Id { get; private set; }
        public string? Title { get; private set; }
        public bool IsDeleted { get; private set; }
        //public DateTime CreationDate { get; private set; }

        public ICollection<Article.Article> Articles { get; private set; }

        protected ArticleCategory()
        {

        }
        public ArticleCategory(string title,IArticleCategoryValidatorService validatorService)
        {
            GaurdAgainstEmptyTitle(title);
            validatorService.CheckThatThisRecordAlreadyExists(title);
            Title = title;
            IsDeleted = false;
           // CreationDate = DateTime.Now;
            Articles = new List<Article.Article>();
        }
        public void Rename(string title)
        {
            GaurdAgainstEmptyTitle(title);
            this.Title = title;
        }
        public void Restore()
        {
            this.IsDeleted = false;
        }
        public void Delete()
        {
            this.IsDeleted=true;
        }


        public void GaurdAgainstEmptyTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new DuplicatedRecordException("make sure you fill the blanck");
            }
        }
    }
}
