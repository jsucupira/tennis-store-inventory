using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Core.Common.Model
{
    /// <summary>
    /// Class QueueMessage.
    /// </summary>
    public class QueueMessage
    {
        public string ObjectId { get; set; }
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; private set; }
        /// <summary>
        /// Gets or sets the type of the message.
        /// </summary>
        /// <value>The type of the message.</value>
        public string MessageType { get; set; }
        /// <summary>
        /// Gets or sets the message identifier.
        /// </summary>
        /// <value>The message identifier.</value>
        public string MessageId { get; set; }

        /// <summary>
        /// Adds the message.
        /// </summary>
        /// <param name="messageObject">The message object.</param>
        public void AddMessage(object messageObject)
        {
            Message = JsonConvert.SerializeObject(messageObject);
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T.</returns>
        public T GetMessage<T>()
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(Message);
            }
            catch (JsonReaderException)
            {

            }

            return default(T);
        }
    }
}