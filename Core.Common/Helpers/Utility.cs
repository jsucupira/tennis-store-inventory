using Core.Common.Model;

namespace Core.Common.Helpers
{
    /// <summary>
    /// Class Utility.
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Adds the entry to queue.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TId">The type of the t identifier.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <returns>QueueMessage.</returns>
        public static QueueMessage AddEntryToQueue<T, TId>(this T entity, string messageType) where T : Entity<TId>
        {
            QueueMessage queueMessage = new QueueMessage { MessageType = $"{messageType}{typeof(T).Name}", ObjectId = entity.Id.ToString() };
            queueMessage.AddMessage(entity);
            return queueMessage;
        }

        /// <summary>
        /// Archives the entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TId">The type of the t identifier.</typeparam>
        /// <param name="oldEntity">The old entity.</param>
        /// <param name="newEntity">The new entity.</param>
        /// <returns>ArchiveMessage.</returns>
        public static ArchiveMessage ArchiveEntity<T, TId>(this T oldEntity, T newEntity) where T : Entity<TId>
        {
            ArchiveMessage archiveMessage = new ArchiveMessage
            {
                ObjectFullName = $"{oldEntity}{typeof(T).FullName}",
                ObjectId = oldEntity.Id.ToString()
            };
            archiveMessage.AddOldObject(oldEntity);
            archiveMessage.AddNewObject(newEntity);
            return archiveMessage;
        }
    }
}
