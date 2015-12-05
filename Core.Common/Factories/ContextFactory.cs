using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Model;

namespace Core.Common.Factories
{
    public static class ContextFactory
    {
        public static T Create<T>()
        {
            return MefBase.Resolve<T>();
        }
    }
}
