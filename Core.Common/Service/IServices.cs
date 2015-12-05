using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Service
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
