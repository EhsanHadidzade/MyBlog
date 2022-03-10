using System.Linq.Expressions;

namespace MyBlog.Domain.Services
{
    public interface IArticleCategoryValidatorService
    {
        void CheckThatThisRecordAlreadyExists(string title);
    }
}
