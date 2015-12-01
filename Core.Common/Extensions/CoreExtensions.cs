using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace Core.Common.Extensions
{
    public static class CoreExtensions
    {
        public static object CreateDynamicShapedObject(this object @object, List<string> fields)
        {
            if (!fields.Any())
                return @object;
            ExpandoObject objectToReturn = new ExpandoObject();
            foreach (string field in fields)
            {
                object value = @object.GetType().GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                    .GetValue(@object, null);
                ((IDictionary<string, object>) objectToReturn).Add(field, value);
            }
            return objectToReturn;
        }

        public static void Merge<T>(this ObservableCollection<T> source, IEnumerable<T> collection, bool ignoreDuplicates = false)
        {
            if (collection != null)
            {
                foreach (T item in collection)
                {
                    bool addItem = true;

                    if (ignoreDuplicates)
                        addItem = !source.Contains(item);

                    if (addItem)
                        source.Add(item);
                }
            }
        }
    }
}