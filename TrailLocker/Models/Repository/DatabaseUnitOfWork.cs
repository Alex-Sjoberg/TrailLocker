using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;

using TrailLocker.Models.Entities;

namespace TrailLocker.Models.Repository
{
    public class DatabaseUnitOfWork : IUnitOfWork
    {
        private TrailLockerDataContext dataContext;

        public DatabaseUnitOfWork()
        {
            dataContext = new TrailLockerDataContext();
        }

        ~DatabaseUnitOfWork()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            if (dataContext != null)
            {
                dataContext.Dispose();
                dataContext = null;
            }
        }

        public void Commit()
        {
            dataContext.SubmitChanges();
        }

        public void Attach<T>(T obj, bool setToChanged = false)
            where T : class
        {
            Table<T> table = GetTable<T>();

            table.Attach(obj, setToChanged);
        }

        public void Add<T>(T obj)
            where T : class
        {
            Table<T> table = GetTable<T>();

            table.InsertOnSubmit(obj);
        }

        public IQueryable<T> Get<T>()
            where T : class
        {
            Table<T> table = GetTable<T>();

            return table.AsQueryable();
        }

        public bool Remove<T>(T item)
            where T : class
        {
            Table<T> table = GetTable<T>();
            table.DeleteOnSubmit(item);

            // What should we be returning here?
            return true;
        }

        private Table<T> GetTable<T>()
            where T : class
        {
            var x = typeof(TrailLockerDataContext).GetFields();
            var y = x.Where(f => f.FieldType == typeof(Table<T>));
            var z = y.Single();
            var a = z.GetValue(dataContext);
            return (Table<T>)a;
            //return (Table<T>)typeof(TrailLockerDataContext).GetFields().Where(f => f.FieldType == typeof(Table<T>)).Single().GetValue(dataContext);
        }
    }
}