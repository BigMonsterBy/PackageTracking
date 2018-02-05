using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackageTracking.Web.Infrastructure.Services
{
    public static class JsonService
    {
        public static T GetObjectsFromJson<T>(string json)
        {
            var obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }
    }
}