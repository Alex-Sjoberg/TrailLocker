/*Andrew Smith
 * Byrant Sell*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using TrailLocker.Models.Entities;
using TrailLocker.Models.Repository;

//using TrailLocker.Models;

namespace TrailLocker.Controllers
{
    [Authorize]
    public class TripController : Controller
    {
        Repository<Trip> tripRepository;
        InMemoryUnitOfWork unitOfWork;

        public TripController()
            : this(new Repository<Trip>(new DatabaseUnitOfWork()))
        {
            
        }

        public TripController(Repository<Trip> repo)
        {
            tripRepository = repo;
        }


        // GET: /Trip/Trips
        // Routed to by GET: /Trip/
        public ActionResult Trips()
        {
            return View(tripRepository.FindAll());
        }

        //Gets view for adding trip
        //GET: /Trip/AddTrip
        public ActionResult AddTrip()
        {
            return View();
        }

        // POST: /Trip/AddTrip
        [HttpPost]
        public ActionResult AddTrip(Trip trip)
        {
            //Add trip to database
            tripRepository.Add(trip);
            tripRepository.Commit();
            return RedirectToAction("Index");
        }

        //GET: /Trip/EditTrip
        [HttpGet]
        public ActionResult EditTrip(Trip trip)
        {
            return View(trip);
        }

        // POST: /Trip/EditTripInDatabase
        [HttpPost]
        public ActionResult EditTripInDatabase(Trip trip)
        {
            tripRepository.Attach(trip);
            tripRepository.Commit();
            return RedirectToAction("Index");
        }

        // GET: /Trip/DeleteTrip
        public ActionResult DeleteTrip(Trip trip)
        {
            tripRepository.Remove(trip);
            tripRepository.Commit();
            return RedirectToAction("Index");
        }

    }
}