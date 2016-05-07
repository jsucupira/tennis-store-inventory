using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MasterData.ProductAggregate
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class Size
    {
        public string Value { get; set; }
        public string SizeUnitOfMeasure { get; set; }
    }
}
