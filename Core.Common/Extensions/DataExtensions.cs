using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Core.Common.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class DataExtensions
    {
        public static List<T> ToFullyLoaded<T>(this IQueryable<T> query)
        {
            return query.ToList();
        }
    }
}