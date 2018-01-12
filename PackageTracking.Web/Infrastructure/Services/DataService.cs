using PackageTracking.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PackageTracking.Web.Infrastructure.Services
{
    public class DataService
    {
        public void WriteObjectToDb<T>(T obj, DbSet where)
        {
            using (PackageTrackingContext db = new PackageTrackingContext(null))
            {
                where.Add(obj);
                db.SaveChanges();
            }
        }
    }
}