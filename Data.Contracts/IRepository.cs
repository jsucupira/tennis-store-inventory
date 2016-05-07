namespace Data.Contracts
{
    public interface IRepository<T, in TId> : IReadOnlyRepository<T, TId>
    {
        T Create(T entity);
        void Update(T entity);
        void Delete(TId id);
    }
}
