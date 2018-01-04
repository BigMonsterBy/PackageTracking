using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTracking.Data.Serializers
{
    class JSONComposer
    {
        public static string Generate<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T Deserealize<T>(string JSON)
        {
            return (T)JsonConvert.DeserializeObject(JSON);
        }
    }
}
