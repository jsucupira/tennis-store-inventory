using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Core.Common.Model
{
    public class ArchiveMessage
    {
        public string ObjectFullName { get; set; }
        public string ObjectId { get; set; }
        public string OldObject { get; private set; }
        public string NewObject { get; private set; }

        public void AddOldObject(object @object)
        {
            OldObject = JsonConvert.SerializeObject(@object);
        }

        public void AddNewObject(object @object)
        {
            NewObject = JsonConvert.SerializeObject(@object);
        }

        public T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
