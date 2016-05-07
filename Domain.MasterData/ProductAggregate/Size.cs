using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MasterData.ProductAggregate
{
    [Serializable]
    public class Size
    {
        public string Value { get; set; }
        public string SizeUnitOfMeasure { get; set; }
    }
}
