using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.Exceptions;
using Core.Common.Model;
using Data.Contracts;

namespace Business.MasterData
{
    /// <summary>
    /// Class SelectorBase.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TId">The type of the t identifier.</typeparam>
    internal class SelectorBase<T, TId> where T: Entity<TId>
    {
        /// <summary>
        /// The read only repository
        /// </summary>
        protected readonly IReadOnlyRepository<T, TId> ReadOnlyRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectorBase{T, TId}"/> class.
        /// </summary>
        /// <param name="readOnlyRepository">The read only repository.</param>
        protected SelectorBase(IReadOnlyRepository<T, TId> readOnlyRepository)
        {
            ReadOnlyRepository = readOnlyRepository;
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="active">if set to <c>true</c> [active].</param>
        /// <returns>List&lt;T&gt;.</returns>
        protected List<T> FindAll(bool active)
        {
            return ReadOnlyRepository.FindAll().Where<T>(t => t.IsActive == active).ToList();
        }

        /// <summary>
        /// Gets the specified entity identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Store.</returns>
        /// <exception cref="NotValidException"></exception>
        /// <exception cref="Core.Common.Exceptions.NotValidException"></exception>
        /// <exception cref="ResourceNotFoundException"></exception>
        /// <exception cref="Core.Common.Exceptions.ResourceNotFoundException"></exception>
        protected T Get(TId id)
        {
            if (id == null)
                CreateErrors.NotValid("", nameof(id));

            if (string.IsNullOrEmpty(id.ToString()) ||id.ToString() == Guid.Empty.ToString() || id.ToString() == "0")
                throw new NotValidException(id.ToString());

            T entity = ReadOnlyRepository.Get(id);
            if (entity == null)
                CreateErrors.NotFound(id);

            return entity;
        }
    }
}