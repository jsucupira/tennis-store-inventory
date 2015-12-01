using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;

namespace Core.Common.Extensions
{
    public static class MefExtensions
    {
        public static CompositionContainer Container;

        public static T GetExportedValueByType<T>(this CompositionContainer container, Type type)
        {
            foreach (ComposablePartDefinition partDef in container.Catalog.Parts)
            {
                foreach (ExportDefinition exportDef in partDef.ExportDefinitions)
                {
                    if (exportDef.ContractName == type.FullName)
                        return (T) partDef.CreatePart().GetExportedValue(exportDef);
                }
            }
            return default(T);
        }

        public static IEnumerable<object> GetExportedValuesByType(this CompositionContainer container, Type type)
        {
            foreach (ComposablePartDefinition partDef in container.Catalog.Parts)
            {
                foreach (ExportDefinition exportDef in partDef.ExportDefinitions)
                {
                    if (exportDef.ContractName == type.FullName)
                    {
                        string contract = AttributedModelServices.GetContractName(type);
                        ContractBasedImportDefinition definition = new ContractBasedImportDefinition(contract, contract, null, ImportCardinality.ExactlyOne, false, false, CreationPolicy.Any);
                        return container.GetExports(definition);
                    }
                }
            }

            return new List<object>();
        }

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
    }
}