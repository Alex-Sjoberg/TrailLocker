using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace COS340.TrailLocker.Data
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        private BinaryFormatter bformatter = new BinaryFormatter();
        private String filename = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\equipmentRepository.txt";
        protected Dictionary<string, object> Database = new Dictionary<string, object>();

        public void readData()
        {
            if (!System.IO.File.Exists(filename))
            {
                Database = new Dictionary<string, object>();
            }
            //read equipmentRepository in from file test.txt
            else
            {
                Stream readStream = System.IO.File.Open(filename, FileMode.Open);
                Database = (Dictionary<string, object>)bformatter.Deserialize(readStream);
                readStream.Close();
            }
        }


        public void Dispose()
        {
            Database = null;
        }

        public void Commit()
        {
            Stream writeStream = System.IO.File.Open(filename, FileMode.Create);
            bformatter.Serialize(writeStream, Database);
            writeStream.Close();
        }
        

        public void Attach<T>(T obj, bool setToChanged = false) where T : class
        {
            Add(obj);
        }

        public void Add<T>(T obj) where T : class
        {
            var table = GetDatabaseTable<T>();
            table.Add(obj);
        }

        public IQueryable<T> Get<T>() where T : class
        {
            var table = GetDatabaseTable<T>();
            return table.AsQueryable();
        }

        public bool Remove<T>(T item) where T : class
        {
            var table = GetDatabaseTable<T>();
            return table.Remove(item);
        }


        protected ICollection<T> GetDatabaseTable<T>() where T : class
        {
            // Get the name of the type
            string key = typeof(T).Name;

            ICollection<T> table;
            if (!Database.Any(x => x.Key == key))
            {
                table = new Collection<T>();
                Database.Add(key, table);
            }
            else
            {
                table = Database[key] as Collection<T>;
            }
            return table;
        }


    }
}
