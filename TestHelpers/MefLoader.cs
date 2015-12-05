using System.ComponentModel.Composition.Hosting;
using Core.Common.Model;

namespace TestHelpers
{
    public static class MefLoader
    {

        private static readonly object _lock = new object();
        public static object SynchronizationLock
        {
            get { return _lock; }
        }
        public static void Initialize()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof (MefLoader).Assembly));
            MefBase.SetContainer(new CompositionContainer(catalog));
        }
    }
}