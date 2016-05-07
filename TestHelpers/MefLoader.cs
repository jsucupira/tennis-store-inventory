using System.ComponentModel.Composition.Hosting;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Business.MasterData;
using Core.Common.Model;

namespace TestHelpers
{
    [ExcludeFromCodeCoverage]
    public static class MefLoader
    {
        public static void Initialize()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof (BusinessMasterDataAssembly).Assembly));
            MefBase.SetContainer(new CompositionContainer(catalog));
        }
    }
}