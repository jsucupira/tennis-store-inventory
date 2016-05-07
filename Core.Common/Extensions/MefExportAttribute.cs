using System;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;

namespace Core.Common.Extensions
{
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Class), MetadataAttribute]
    public class MefExportAttribute : ExportAttribute, INameMetaData
    {
        public MefExportAttribute(Type contractType, string name) : base(contractType)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}