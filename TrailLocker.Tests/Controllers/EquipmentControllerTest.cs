using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TrailLocker.Controllers;
using TrailLocker.Models;
using System.Web.Mvc;
using System.Linq;

namespace TrailLocker.Tests.Controllers
{
    [TestClass]
    public class EquipmentControllerTest
    {
        private IQueryable<EquipmentModel> equipment;

        public EquipmentControllerTest()
        {
            List<EquipmentModel> temp = new List<EquipmentModel>();

            temp.Add(new EquipmentModel() { Name = "Sleeping Bag", Weight = 2.0, Category = EquipmentCategory.Other, EquipmentID = 1 });
            temp.Add(new EquipmentModel() { Name = "Pizza", Weight = 120, Category = EquipmentCategory.Perishable, EquipmentID = 2 });
            temp.Add(new EquipmentModel() { Name = "Water Bottle", Weight = 10, Category = EquipmentCategory.Expendable, EquipmentID = 3 });
            temp.Add(new EquipmentModel() { Name = "Backpack", Weight = 50, Category = EquipmentCategory.Backpack, EquipmentID = 4 });
            temp.Add(new EquipmentModel() { Name = "Chips", Weight = 5, Category = EquipmentCategory.Perishable, EquipmentID = 5 });

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

            ViewResult result = controller.Search(new EquipmentSearchModel() { Category = EquipmentCategory.Backpack }) as ViewResult;
            IEnumerable<EquipmentModel> model = result.Model as IEnumerable<EquipmentModel>;

            Assert.AreEqual(1, model.Count(), "The category search for backpack should return one object");

            Assert.AreEqual("Backpack", model.Single().Name, "The name search returned the wrong equipment");
        }

        [TestMethod]
        public void Search_Category_And_Name()
        {
            EquipmentController controller = new EquipmentController();

            ViewResult result = controller.Search(new EquipmentSearchModel() { Category = EquipmentCategory.Perishable, Name = "Chips" }) as ViewResult;
            IEnumerable<EquipmentModel> model = result.Model as IEnumerable<EquipmentModel>;

            Assert.AreEqual(1, model.Count(), "The category search for backpack should return one object");

            Assert.AreEqual("Chips", model.Single().Name);
        }
    }
}
