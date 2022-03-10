using _01_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Infrastructure
{
    public interface IRepository<in Tkey,T> where T:DomainBase<Tkey>
    {
        void Create(T entity);
        T Get(Tkey id);
        List<T> GetAll();
        bool IsExist(Expression<Func<T, bool>> expression);
    }
}
