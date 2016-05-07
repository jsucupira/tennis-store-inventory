using System.ComponentModel.Composition.Hosting;
using System.Diagnostics.CodeAnalysis;
using Core.Common.Extensions;

namespace Core.Common.Model
{
    [ExcludeFromCodeCoverage]
    public static class MefBase
    {
        public static CompositionContainer Container { get; private set; }

        public static void SetContainer(CompositionContainer container)
        {
            Container = container;
        }

        public static T Resolve<T>()
        {
            return Container.GetExportedValue<T>();
        }
    }
}