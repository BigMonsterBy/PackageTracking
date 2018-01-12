using PackageTracking.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PackageTracking.Web.Infrastructure.Services
{
    public interface IDataService
    {
        void WriteObjectToDb<T>(T obj, DbSet where);
    }

    public class DataService : IDataService
    {
        private readonly PackageTrackingContext _packageTrackingContext;

        public DataService(PackageTrackingContext packageTrackingContext)
        {
            _packageTrackingContext = packageTrackingContext;
        }

        public void WriteObjectToDb<T>(T obj, DbSet where)
        {
            where.Add(obj);
            _packageTrackingContext.SaveChanges();
        }
    }
}