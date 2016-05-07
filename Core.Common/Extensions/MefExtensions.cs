using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Core.Common.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class MefExtensions
    {
        public static T ResolveCustomExportValue<T>(this ExportProvider container, string name)
        {
            if (container == null)
                throw new Exception("MEF composition container is null.");

            T export = container.GetExports<T, INameMetaData>().Where(t => t.Metadata.Name.ToString().Equals(name)).Select(t => t.Value).FirstOrDefault();
            if (export == null)
                throw new Exception($"Could not resolve MEF Export for '{typeof(T).Name}' with the name {name}.");

            return export;
        }
    }
}