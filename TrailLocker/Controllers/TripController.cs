/*Andrew Smith
 * Byrant Sell*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using TrailLocker.Models;

namespace TrailLocker.Controllers
{
    //[Authorize]
    //public class TripController : Controller
    //{
    //    Repository<TripModel> tripRepository;
    //    InMemoryUnitOfWork unitOfWork;
        
    //    public TripController()
    //    {
    //        unitOfWork = new InMemoryUnitOfWork();
    //        tripRepository = new Repository<TripModel>(unitOfWork);
    //    }
        
    //    // GET: /Trip/Trips
    //    // Routed to by GET: /Trip/
    //    public ActionResult Trips()
    //    {
    //        CreateTrips();
    //        return View(tripRepository.FindAll());
    //    }

    //    //Gets view for adding trip
    //    //GET: /Trip/AddTrip
    //    public ActionResult AddTrip()
    //    {
    //        return View();
    //    }
        
    //    // POST: /Trip/AddTrip
    //    [HttpPost]
    //    public ActionResult AddTrip(TripModel trip)
    //    {
    //        //Add trip to database
    //        tripRepository.Add(trip);
    //        return RedirectToAction("Index");
    //    }

    //    //GET: /Trip/EditTrip
    //    [HttpGet]
    //    public ActionResult EditTrip(TripModel trip)
    //    {
    //        tripRepository.Remove(trip);
    //        return View(trip);
    //    }

    //    // POST: /Trip/EditTripInDatabase
    //    [HttpPost]
    //    public ActionResult EditTripInDatabase(TripModel trip)
    //    {
    //        //edit trip in database
    //        tripRepository.Add(trip);
    //        return RedirectToAction("Trips");
    //    }

    //    // POST: /Trip/DeleteTrip
      
    //    public ActionResult DeleteTrip(TripModel trip)
    //    {
    //        //Delete trip from database
    //        tripRepository.Remove(trip);
    //        return RedirectToAction("Trips");
    //    }

    //    public Repository<TripModel> CreateTrips()
    //    {
    //        tripRepository.Add(new TripModel() { TripName = "Fall 2012", 
    //                                             DestinationName = "Colorado", 
    //                                             StartYear = 2012, 
    //                                             StartMonth = 9, 
    //                                             StartDay = 15, 
    //                                             EndYear = 2012, 
    //                                             EndMonth = 9, 
    //                                             EndDay = 19 });
    //        tripRepository.Add(new TripModel() { TripName = "Fall 2013", 
    //                                             DestinationName = "Florida", 
    //                                             StartYear = 2013, 
    //                                             StartMonth = 10, 
    //                                             StartDay = 18, 
    //                                             EndYear = 2013, 
    //                                             EndMonth = 10, 
    //                                             EndDay = 20 });
    //        tripRepository.Add(new TripModel() { TripName = "Summer 2013", 
    //                                             DestinationName = "Egypt", 
    //                                             StartYear = 2013, 
    //                                             StartMonth = 6, 
    //                                             StartDay = 15, 
    //                                             EndYear = 2013, 
    //                                             EndMonth = 6, 
    //                                             EndDay = 19 });

    //        return tripRepository;
    //    }

    //}
}