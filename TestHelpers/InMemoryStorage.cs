using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Core.Common.Model;

namespace TestHelpers
{
    [ExcludeFromCodeCoverage]
    public class InMemoryStorage<T, TId> where T : Entity<TId>
    {
        private static readonly Dictionary<Type, Dictionary<string, object>> _tables = new Dictionary<Type, Dictionary<string, object>>();

        private Dictionary<string, object> Table
        {
            get
            {
                lock (_tables)
                {
                    Dictionary<string, object> table = null;

                    if (_tables.ContainsKey(typeof(T)))
                        table = _tables[typeof(T)];
                    else
                    {
                        table = new Dictionary<string, object>();
                        _tables.Add(typeof(T), table);
                    }
                    return table;
                }
            }
        }

        public T Create(T entity)
        {
            Table.Add(entity.Id.ToString(), entity);
            return entity;
        }

        public List<T> FindAll()
        {
            List<T> items = new List<T>();

            foreach (KeyValuePair<string, object> keyValuePair in Table)
                items.Add(keyValuePair.Value as T);
            return items;
        }

        public T Get(TId id)
        {
            if (Table.ContainsKey(id.ToString()))
                return Table[id.ToString()] as T;

            return default(T);
        }

        public void Update(T entity)
        {
            Table[entity.Id.ToString()] = entity;
        }

        public void Delete(TId id)
        {
            if (Table.ContainsKey(id.ToString()))
                Table.Remove(id.ToString());
        }
    }
}