namespace Data.Contracts
{
    public interface IServices<T>
    {
        T Get(string key);
        void Save(T entity);
    }
}