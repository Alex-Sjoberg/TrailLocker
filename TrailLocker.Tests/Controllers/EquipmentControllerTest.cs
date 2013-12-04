using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TrailLocker.Controllers;
using TrailLocker.Models;
using System.Web.Mvc;
using System.Linq;

using TrailLocker.Models.Entities;
using TrailLocker.Models.Repository;


namespace TrailLocker.Tests.Controllers
{
    [TestClass]
    public class EquipmentControllerTest
    {
        private IQueryable<EquipmentModel> equipment;

        public EquipmentControllerTest()
        {
            List<EquipmentModel> temp = new List<EquipmentModel>();

            temp.Add(new EquipmentModel() { Name = "Sleeping Bag", Weight = 2.0, Category = TrailLocker.Models.EquipmentCategory.General, EquipmentID = 1 });
            temp.Add(new EquipmentModel() { Name = "Pizza", Weight = 120, Category = TrailLocker.Models.EquipmentCategory.Perishable, EquipmentID = 2 });
            temp.Add(new EquipmentModel() { Name = "Water Bottle", Weight = 10, Category = TrailLocker.Models.EquipmentCategory.Expendable, EquipmentID = 3 });
            temp.Add(new EquipmentModel() { Name = "Backpack", Weight = 50, Category = TrailLocker.Models.EquipmentCategory.Backpack, EquipmentID = 4 });
            temp.Add(new EquipmentModel() { Name = "Chips", Weight = 5, Category = TrailLocker.Models.EquipmentCategory.Perishable, EquipmentID = 5 });

            equipment = temp.AsQueryable();
        }

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Search_Returns_View()
        {
            EquipmentController controller = new EquipmentController();

            ViewResult result = controller.Search(new EquipmentSearchModel()) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Search_Name()
        {
            EquipmentController controller = new EquipmentController();

            ViewResult result = controller.Search(new EquipmentSearchModel() { Name = "Pizza" }) as ViewResult;
            IEnumerable<EquipmentModel> model = result.Model as IEnumerable<EquipmentModel>;

            Assert.AreEqual(1, model.Count(), "The name search should only return one object.");

            Assert.AreEqual("Pizza", model.Single().Name, "The name search returned the wrong equipment");
        }

        [TestMethod]
        public void Search_Weight_Min()
        {
            EquipmentController controller = new EquipmentController();

            ViewResult result = controller.Search(new EquipmentSearchModel() { MinWeight = 100 }) as ViewResult;
            IEnumerable<EquipmentModel> model = result.Model as IEnumerable<EquipmentModel>;

            Assert.AreEqual(1, model.Count(), "The weight search, using only min, should return one object");

            Assert.AreEqual("Pizza", model.Single().Name, "The name search returned the wrong equipment");
        }

        [TestMethod]
        public void Search_Weight()
        {
            EquipmentController controller = new EquipmentController();

            ViewResult result = controller.Search(new EquipmentSearchModel() { MinWeight = 100, MaxWeight = 125 }) as ViewResult;
            IEnumerable<EquipmentModel> model = result.Model as IEnumerable<EquipmentModel>;

            Assert.AreEqual(1, model.Count(), "The weight search, using only min, should return one object");

            Assert.AreEqual("Pizza", model.Single().Name, "The name search returned the wrong equipment");
        }

        [TestMethod]
        public void Search_Category()
        {
            EquipmentController controller = new EquipmentController();

            ViewResult result = controller.Search(new EquipmentSearchModel() { Category = TrailLocker.Models.EquipmentCategory.Backpack }) as ViewResult;
            IEnumerable<EquipmentModel> model = result.Model as IEnumerable<EquipmentModel>;

            Assert.AreEqual(1, model.Count(), "The category search for backpack should return one object");

            Assert.AreEqual("Backpack", model.Single().Name, "The name search returned the wrong equipment");
        }

        [TestMethod]
        public void Search_Category_And_Name()
        {
            EquipmentController controller = new EquipmentController();

            ViewResult result = controller.Search(new EquipmentSearchModel() { Category = TrailLocker.Models.EquipmentCategory.Perishable, Name = "Chips" }) as ViewResult;
            IEnumerable<EquipmentModel> model = result.Model as IEnumerable<EquipmentModel>;

            Assert.AreEqual(1, model.Count(), "The category search for backpack should return one object");

            Assert.AreEqual("Chips", model.Single().Name);
        }
    }

    [TestClass]
    public class AddEditDeleteTest
    {
        private Repository<Equipment> repo;
        private Equipment equip1 = new Equipment() { EquipmentID = 1, Name = "alpha", Category = 0, Weight = 5, Location = "there", IsDefault = false };
        private Equipment equip2 = new Equipment() { EquipmentID = 2, Name = "beta", Category = 0, Weight = 4.18, Location = "here", IsDefault = true };

        public AddEditDeleteTest()
        {
            repo = new Repository<Equipment>(new InMemoryUnitOfWork());
            repo.Add(equip1);
            repo.Add(equip2);
        }

        [TestMethod]
        public void IndexShouldReturnView()
        {
            EquipmentController controller = new EquipmentController(repo);
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DefaultShouldReturnView()
        {
            EquipmentController controller = new EquipmentController(repo);
            ViewResult result = controller.Default() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddShouldReturnView()
        {
            EquipmentController controller = new EquipmentController(repo);
            ViewResult result = controller.Add() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditShouldReturnView()
        {
            EquipmentController controller = new EquipmentController(repo);
            ViewResult result = controller.Edit(2) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexShouldListCorrectTrips()
        {
            EquipmentController controller = new EquipmentController(repo);
            ViewResult result = controller.Index() as ViewResult;
            IEnumerable<Equipment> model = result.Model as IEnumerable<Equipment>;
            Assert.AreEqual(2, model.Count());
            Assert.IsTrue(model.Contains(equip1));
            Assert.IsTrue(model.Contains(equip2));
        }

        [TestMethod]
        public void DefaultShouldListCorrectTrips()
        {
            EquipmentController controller = new EquipmentController(repo);
            ViewResult result = controller.Default() as ViewResult;
            IEnumerable<Equipment> model = result.Model as IEnumerable<Equipment>;
            Assert.AreEqual(1, model.Count());
            Assert.IsFalse(model.Contains(equip1));
            Assert.IsTrue(model.Contains(equip2));
        }
/*
        [TestMethod]
        public void AddShouldAddNewEquipmentToRepository()
        {
            EquipmentController controller = new EquipmentController(repo);
            Equipment equip3 = new Equipment() { EquipmentID = 3, Name = "gamma", Category = 0, Weight = 12.7, Location = "wherever", IsDefault = true };
            controller.Add(equip3);
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            IEnumerable<Equipment> model = result.Model as IEnumerable<Equipment>;
            Assert.AreEqual(3, model.Count());
            Assert.IsTrue(model.Contains(equip3));
        }*/

        [TestMethod]
        public void EditShouldChangePreviouslyAddedEquipment()
        {
            EquipmentController controller = new EquipmentController(repo);
            Equipment equip2changed = new Equipment() { EquipmentID = 2, Name = "theta", Category = 0, Weight = 4.65, Location = "somewhere", IsDefault = true };
            controller.Edit(equip2changed);
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            IEnumerable<Equipment> model = result.Model as IEnumerable<Equipment>;
            Assert.AreEqual(2, model.Count());
            Equipment temp = model.ElementAt(1);
            Assert.AreEqual(equip2changed.EquipmentID, temp.EquipmentID);
            Assert.AreEqual(equip2changed.Name, temp.Name);
            Assert.AreEqual(equip2changed.Category, temp.Category);
            Assert.AreEqual(equip2changed.Weight, temp.Weight);
            Assert.AreEqual(equip2changed.Location, temp.Location);
            Assert.AreEqual(equip2changed.IsDefault, temp.IsDefault);
        }

        [TestMethod]
        public void DeleteShouldRemoveEquipment()
        {
            EquipmentController controller = new EquipmentController(repo);
            controller.Delete(2);
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            IEnumerable<Equipment> model = result.Model as IEnumerable<Equipment>;
            Assert.AreEqual(1, model.Count());
            Assert.IsFalse(model.Contains(equip2));
        }

        [TestMethod]
        public void RemoveShouldSetEquipmentToNotDefault()
        {
            EquipmentController controller = new EquipmentController(repo);
            controller.DefaultRemove(2);
            ViewResult result = controller.Default() as ViewResult;
            Assert.IsNotNull(result);
            IEnumerable<Equipment> model = result.Model as IEnumerable<Equipment>;
            Assert.AreEqual(0, model.Count());
            Assert.IsFalse(model.Contains(equip2));
        }
    }
}
