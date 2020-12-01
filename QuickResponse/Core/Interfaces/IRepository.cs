using System.Collections.Generic;

namespace QuickResponse.Core.Interfaces
{
    interface IRepository<T>
    {
        IEnumerable<T> List();
        bool Save(T entity);
        bool Delete(T entity);
        T GetByID(int id);
        bool DeleteById(int id);
        bool Update(T entity);
    }
}
