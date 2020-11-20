using System.Collections.Generic;

namespace QuickResponse.Core.Interfaces
{
    interface IRepository<T>
    {
        IEnumerable<T> List();
        bool Save(T entity);
        bool Delete(T entity);
        T GetByID(string id);
        bool DeleteById(string id);
        bool Update(T entity);
    }
}
