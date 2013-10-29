using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrailLocker.Models.Entities;
using TrailLocker.Models.Repository;
using TrailLocker.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace TrailLocker.Tests.Controllers
{
    [TestClass]
    public class TripControllerTest
    {
        private Repository<Trip> repo;
        private Trip trip1 = new Trip() { TripID = 1, DestinationID = 1, StartDate = new DateTime(2013, 6, 1), EndDate = new DateTime(2013, 6, 4) };
        private Trip trip2 = new Trip() { TripID = 2, DestinationID = 2, StartDate = new DateTime(2013, 7, 15), EndDate = new DateTime(2013, 7, 17) };

        public TripControllerTest()
        {
            repo = new Repository<Trip>(new InMemoryUnitOfWork());
            repo.Add(trip1);
            repo.Add(trip2);
        }

        [TestMethod]
        public void TripsShouldReturnsView()
        {
            TripController controller = new TripController(repo);
            ViewResult result = controller.Trips() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TripsShouldListCorrectTrips()
        {
            TripController controller = new TripController(repo);
            ViewResult result = controller.Trips() as ViewResult;
            IEnumerable<Trip> model = result.Model as IEnumerable<Trip>;
            Assert.AreEqual(2, model.Count());
            Assert.IsTrue(model.Contains(trip1));
            Assert.IsTrue(model.Contains(trip2));

        }

        [TestMethod]
        public void AddTripShouldReturnView()
        {
            TripController controller = new TripController(repo);
            ViewResult result = controller.AddTrip() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void shouldAddNewTripToRepository()
        {
            TripController controller = new TripController(repo);
            Trip trip3 = new Trip() { TripID = 3, DestinationID = 1, StartDate = new DateTime(2013, 1, 1), EndDate = new DateTime(2013, 2, 1)};
            controller.AddTrip(trip3);
            ViewResult result = controller.Trips() as ViewResult;
            Assert.IsNotNull(result);
            IEnumerable<Trip> model = result.Model as IEnumerable<Trip>;
            Assert.AreEqual(3, model.Count());
            Assert.IsTrue(model.Contains(trip3));
        }

        [TestMethod] 
        public void EditTripShouldReturnView()
        {
            TripController controller = new TripController(repo);
            Trip trip4 = new Trip() { TripID = 4, DestinationID = 3, StartDate = new DateTime(2005, 3, 1), EndDate = new DateTime(2005, 3, 4)};
            ViewResult result = controller.EditTrip(trip4) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditTripInDatabaseShouldChangePreviouslyAddedTrip()
        {
            TripController controller = new TripController(repo);
            Trip trip2changed = new Trip() { TripID = 2, DestinationID = 1, StartDate = new DateTime(2013, 12, 1), EndDate = new DateTime(2013, 12, 3) };
            ViewResult result = controller.EditTripInDatabase(trip2changed) as ViewResult;
            Assert.IsNotNull(result);
            IEnumerable<Trip> model = result.Model as IEnumerable<Trip>;
            Assert.AreEqual(2, model.Count());
            Assert.IsTrue(model.Contains(trip2changed));
            Assert.IsFalse(model.Contains(trip2));
        }

        [TestMethod]
        public void DeleteTripShouldRemoveTrip()
        {
            TripController controller = new TripController(repo);
            ViewResult result = controller.DeleteTrip(trip2) as ViewResult;
            Assert.IsNotNull(result);
            IEnumerable<Trip> model = result.Model as IEnumerable<Trip>;
            Assert.AreEqual(1, model.Count());
            Assert.IsFalse(model.Contains(trip2));
        }
    }
}
