using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrailLocker.Models.Entities;
using TrailLocker.Models.Repository;
using TrailLocker.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;

namespace TrailLocker.Tests.Controllers
{
    [TestClass]
    public class TripControllerTest
    {
        private Repository<Trip> repo;

        public TripControllerTest()
        {
            repo = new Repository<Trip>(new InMemoryUnitOfWork());
            repo.Add(new Trip() { TripID = 1, DestinationID = 1, StartDate = new DateTime(2013, 6, 1), EndDate = new DateTime(2013, 6, 4) });
            repo.Add(new Trip() { TripID = 2, DestinationID = 2, StartDate = new DateTime(2013, 7, 15), EndDate = new DateTime(2013, 7, 17) });
        }

        [TestMethod]
        public void TripsReturnsView()
        {
            TripController controller = new TripController(repo);
            ViewResult result = controller.Trips() as ViewResult;
            Assert.IsNotNull(result);
        }

        public void TripsListsCorrectTrips()
        {
            TripController controller = new TripController(repo);
            ViewResult result = controller.Trips() as ViewResult;
            IEnumerable<Trip> model = result.Model as IEnumerable<Trip>;
            Assert.AreEqual(2, model.Count());
        }

        [TestMethod]
        public void shouldAddNewTripToRepository()
        {
            TripController controller = new TripController(repo);
            
        }
    }
}
