﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;

namespace Core.Common.Extensions
{
    public static class MefExtensions
    {
        public static T ResolveExportedValue<T>(this ExportProvider container)
        {
            if (container == null)
                throw new Exception("MEF composition container is null.");

            IEnumerable<T> exports = container.GetExportedValues<T>();
            IEnumerable<T> enumerable = exports as T[] ?? exports.ToArray();
            if (enumerable.Count() == 1)
                return enumerable.First();
            if (!enumerable.Any())
                throw new Exception($"Could not resolve MEF Export for '{typeof (T).Name}'.");
            return enumerable.Last();
        }

        public static T ResolveCustomExportValue<T>(this ExportProvider container, string name)
        {
            if (container == null)
                throw new Exception("MEF composition container is null.");

            T export = container.GetExports<T, INameMetaData>().Where(t => t.Metadata.Name.ToString().Equals(name)).Select(t => t.Value).FirstOrDefault();
            if (export == null)
                throw new Exception(string.Format("Could not resolve MEF Export for '{0}' with the name {1}.", typeof(T).Name, name));

            return export;
        }

        public static T ResolveExportedValue<T>(this ExportProvider container, string className)
        {
            if (container == null)
                throw new Exception("MEF composition container is null.");

            IEnumerable<T> exports = container.GetExportedValues<T>();
            IEnumerable<T> enumerable = exports as T[] ?? exports.ToArray();
            if (!enumerable.Any())
                throw new Exception($"Could not resolve MEF Export for '{typeof(T).Name}'.");
            foreach (T export in enumerable)
            {
                if (export.GetType().Name.Equals(className, StringComparison.InvariantCultureIgnoreCase))
                    return export;
            }
            throw new Exception($"Could not resolve MEF Export for '{typeof(T).Name}' with class name '{className}'. (multiple exports)");
        }
    }
}