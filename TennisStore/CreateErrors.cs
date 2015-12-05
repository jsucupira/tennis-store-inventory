using Core.Common.Exceptions;

namespace TennisStore
{
    internal static class CreateErrors
    {
        public static void ItemAlreadyExists(object itemId)
        {
            throw new ResourceAlreadyExistsException(string.Format(Messages.OBJECT_EXISTS, itemId));
        }

        public static void ItemDoesntExist(object itemId)
        {
            throw new ResourceNotFoundException(string.Format(Messages.OBJECT_DONT_EXISTS, itemId));
        }

        public static void ItemIsLocked(object itemId, string lockedBy)
        {
            throw new LockedException(string.Format(Messages.OBJECT_IS_LOCKED, itemId, lockedBy));
        }

        public static void UnableToUnlock(string lockedBy)
        {
            throw new LockedException(string.Format(Messages.UNABLE_TO_UNLOCK, lockedBy));
        }

        public static void NotValid(string value, string property)
        {
            throw new NotValidException(string.Format(Messages.NOT_VALID, value, property));
        }
    }
}
