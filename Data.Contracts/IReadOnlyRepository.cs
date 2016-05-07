using System.Collections.Generic;

namespace Data.Contracts
{
    public interface IReadOnlyRepository<T, in TId>
    {
        T Get(TId id);
        List<T> FindAll();
    }
}