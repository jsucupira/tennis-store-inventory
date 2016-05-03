using System.Runtime.Caching;

namespace Data.Contracts
{
    public interface ICaching
    {
        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="dataObject">The data object.</param>
        /// <param name="section">The section.</param>
        /// <param name="policy">The policy.</param>
        void Set(string key, object dataObject, string section, CacheItemPolicy policy);

        /// <summary>
        /// Check if key exists
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="section">The section.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool Exists(string key, string section);

        /// <summary>
        /// Gets the object specified by the key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="section">The section.</param>
        /// <returns>T.</returns>
        T Get<T>(string key, string section);

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="section">The section.</param>
        void Remove(string key, string section);

        /// <summary>
        /// Removes all item for that section.
        /// </summary>
        /// <param name="section">The section.</param>
        void RemoveAll(string section);
    }
}