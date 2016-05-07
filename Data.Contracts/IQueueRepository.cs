using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Model;

namespace Data.Contracts
{
    public interface IQueueRepository
    {
        void AddToQueue(QueueMessage queueMessage);
    }
}
