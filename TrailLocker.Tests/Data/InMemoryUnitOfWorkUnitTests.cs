using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrailLocker.Data;

namespace TrailLocker.Tests.Data
{
    [TestClass]
    public class InMemoryUnitOfWorkUnitTests
    {
        private class TestInMemoryUnitOfWork : InMemoryUnitOfWork
        {
            public Dictionary<string, object> GetDatabase()
            {
                return Database;
            }

            public new ICollection<T> GetDatabaseTable<T>() where T : class
            {
                return base.GetDatabaseTable<T>();
            }
        }

        private class MyTestClass
        {
            
        }


        [TestMethod]
        public void InMemoryUnitOfWork_When_Adding_An_object_For_The_First_Time_Should_Create_A_Database_Key()
        {
            MyTestClass myTestClass = new MyTestClass();

            TestInMemoryUnitOfWork unitOfWork = new TestInMemoryUnitOfWork();
            
            unitOfWork.Add(myTestClass);

            var database = unitOfWork.GetDatabase();
            Assert.AreEqual(1, database.Count);
            Assert.IsTrue(database.ContainsKey("MyTestClass"));
        }

        [TestMethod]
        public void InMemoryUnitOfWork_When_Adding_An_object_Should_Add_To_The_Type_Collection()
        {
            MyTestClass myTestClass = new MyTestClass();
            MyTestClass myTestClass2 = new MyTestClass();

            TestInMemoryUnitOfWork unitOfWork = new TestInMemoryUnitOfWork();

            unitOfWork.Add(myTestClass);
            unitOfWork.Add(myTestClass2);

            var database = unitOfWork.GetDatabase();
            var table = database["MyTestClass"] as Collection<MyTestClass>;


            Assert.AreEqual(2, table.Count);
            Assert.IsTrue(table.Any(x => x == myTestClass));
            Assert.IsTrue(table.Any(x => x == myTestClass2));
        }

        [TestMethod]
        public void InMemoryUnitOfWork_When_Calling_Get_Should_Return_A_Queryable_Collection()
        {
            MyTestClass myTestClass = new MyTestClass();

            TestInMemoryUnitOfWork unitOfWork = new TestInMemoryUnitOfWork();

            unitOfWork.Add(myTestClass);

            var query = unitOfWork.Get<MyTestClass>();
            Assert.IsNotNull(query);
            Assert.IsInstanceOfType(query, typeof(IQueryable<MyTestClass>));
        }

        [TestMethod]
        public void InMemoryUnitOfWork_When_Calling_Remove_Should_Remove_The_Correct_Object()
        {
            MyTestClass myTestClass = new MyTestClass();
            MyTestClass myTestClass2 = new MyTestClass();
            MyTestClass myTestClass3 = new MyTestClass();

            TestInMemoryUnitOfWork unitOfWork = new TestInMemoryUnitOfWork();

            unitOfWork.Add(myTestClass);
            unitOfWork.Add(myTestClass2);
            unitOfWork.Add(myTestClass3);

            var result = unitOfWork.Remove(myTestClass2);

            Assert.IsTrue(result);

            var table = unitOfWork.GetDatabaseTable<MyTestClass>();

            // We got rid of one of them, so there should only be 2 records
            Assert.AreEqual(2, table.Count);
            Assert.IsTrue(table.Any(x => x == myTestClass));
            Assert.IsTrue(table.Any(x => x == myTestClass3));
            Assert.IsFalse(table.Any(x => x == myTestClass2));


        }


    }

    
}
