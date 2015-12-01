﻿using System.Collections.Generic;
using System.Linq;

namespace Core.Common.Extensions
{
    public static class DataExtensions
    {
        public static List<T> ToFullyLoaded<T>(this IQueryable<T> query)
        {
            return query.ToArray().ToList();
        }
    }
}