using System;
using System.ComponentModel.Composition;

namespace Core.Common.Extensions
{
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