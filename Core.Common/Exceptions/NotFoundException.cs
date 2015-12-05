using System;

namespace Core.Common.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException(string @object, string id) : base($"The resource {@object} was not find with id {id}.")
        {

        }
    }
}