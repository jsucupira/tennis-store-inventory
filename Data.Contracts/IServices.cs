using System.Collections.Generic;

namespace Data.Contracts
{
    public interface IServices<T, in TId>
    {
        T Get(TId id);
        List<T> FindAll();
        T Create(T entity);
        void Update(T entity);
        void Delete(TId id);
    }
}
