using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Model;
using Data.Contracts;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;

namespace TestHelpers.Mocks
{
    [ExcludeFromCodeCoverage]
    [Export(typeof(IArchiverRepository))]
    internal class ArchiverMock : IArchiverRepository
    {
        public void Archive(ArchiveMessage archiveMessage)
        {
            
        }
    }

    [ExcludeFromCodeCoverage]
    [Export(typeof(IQueueRepository))]
    internal class QueueMock: IQueueRepository
    {
        public void AddToQueue(QueueMessage queueMessage)
        {
            
        }
    }
}
