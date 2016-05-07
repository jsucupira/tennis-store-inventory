using Core.Common.Helpers;
using Core.Common.Model;
using Core.Common.Service;
using Data.Contracts;

namespace Business.MasterData
{
    /// <summary>
    /// Class UpdatorBase.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TId">The type of the t identifier.</typeparam>
    internal class UpdatorBase<T, TId> where T : Entity<TId>
    {
        /// <summary>
        /// The repository
        /// </summary>
        protected readonly IRepository<T, TId> Repository;
        /// <summary>
        /// The _archiver repository
        /// </summary>
        private readonly IArchiverRepository _archiverRepository;
        /// <summary>
        /// The _queue repository
        /// </summary>
        private readonly IQueueRepository _queueRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdatorBase{T, TId}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="archiverRepository">The archiver repository.</param>
        /// <param name="queueRepository">The queue repository.</param>
        protected UpdatorBase(IRepository<T, TId> repository, IArchiverRepository archiverRepository, IQueueRepository queueRepository)
        {
            Repository = repository;
            _archiverRepository = archiverRepository;
            _queueRepository = queueRepository;
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        protected T Create(T entity)
        {
            if (entity == null)
                CreateErrors.NotValid("", nameof(entity));

            if (Repository.Get(entity.Id) != null)
                CreateErrors.ItemAlreadyExists(entity.Id);

            entity.ModifiedBy(ServiceBase.GetUserName());
            entity.Validate();
            entity.Activate();
            T newEntity = Repository.Create(entity);
            _queueRepository.AddToQueue(newEntity.AddEntryToQueue<T, TId>("Create"));
            return newEntity;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected void Delete(TId id)
        {
            if (id == null)
                CreateErrors.NotValid("", nameof(id));

            if (id is string)
            {
                if (string.IsNullOrEmpty(id.ToString()))
                    CreateErrors.NotValid(id.ToString(), nameof(id));
            }
            
            T entity = Repository.Get(id);

            if (entity != null)
            {
                T original = entity.Clone();
                entity.ModifiedBy(ServiceBase.GetUserName());
                entity.DeActivate();
                Repository.Update(entity);
                _archiverRepository.Archive(original.ArchiveEntity<T, TId>(entity));
                _queueRepository.AddToQueue(entity.AddEntryToQueue<T, TId>("Delete"));
            }
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected void Update(T entity)
        {
            if (entity == null)
                CreateErrors.NotValid("", nameof(entity));

            T original = Repository.Get(entity.Id);
            entity.ModifiedBy(ServiceBase.GetUserName());
            entity.Validate();
            Repository.Update(entity);
            _archiverRepository.Archive(original.ArchiveEntity<T, TId>(entity));
            _queueRepository.AddToQueue(entity.AddEntryToQueue<T, TId>("Update"));
        }
    }
}