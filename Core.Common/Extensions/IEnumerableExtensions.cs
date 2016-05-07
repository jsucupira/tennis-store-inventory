using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;

namespace Core.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> AsEmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }

        private static DataTable ConvertTo<T>(this IEnumerable<T> list, string[] rowsToExclude)
        {
            DataTable table = CreateTable<T>(rowsToExclude);
            Type entityType = typeof (T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (T item in list)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    if (rowsToExclude != null && rowsToExclude.Any(t => t.Equals(prop.Name, StringComparison.OrdinalIgnoreCase)))
                        continue;
                    if (prop.PropertyType.Name != "ICollection`1")
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }

                table.Rows.Add(row);
            }

            return table;
        }

        private static DataTable CreateTable<T>(string[] rowsToExclude)
        {
            Type entityType = typeof (T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
            {
                if (rowsToExclude != null && rowsToExclude.Any(t => t.Equals(prop.Name, StringComparison.OrdinalIgnoreCase)))
                    continue;
                if (prop.PropertyType.Name != "ICollection`1")
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            return table;
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T element in source)
            {
                action(element);
            }
        }

        public static string WriteToCsvFile<T>(this IEnumerable<T> items, string delimiter, string[] rowsToExclude = null)
        {
            DataTable table = items.ConvertTo(rowsToExclude);
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < table.Columns.Count; i++)
            {
                result.Append(table.Columns[i].ColumnName);
                result.Append(i == table.Columns.Count - 1 ? "\r\n" : delimiter);
            }

            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    result.Append(string.Format("\"{0}\"", row[i]));
                    result.Append(i == table.Columns.Count - 1 ? "\r\n" : delimiter);
                }
            }
            return result.ToString();
        }

        public static IEnumerable<T> ApplySort<T>(this IEnumerable<T> source, string sort)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (sort == null)
            {
                return source;
            }

            // split the sort string
            string[] lstSort = sort.Split(',');

            // run through the sorting options and apply them - in reverse
            // order, otherwise results will come out sorted by the last 
            // item in the string first!
            foreach (string sortOption in lstSort.Reverse())
            {
                // if the sort option starts with "-", we order
                // descending, otherwise ascending

                if (sortOption.StartsWith("-"))
                {
                    source = source.OrderBy(sortOption.Remove(0, 1) + " descending");
                }
                else
                {
                    source = source.OrderBy(sortOption);
                }

            }

            return source;
        }
    }
}