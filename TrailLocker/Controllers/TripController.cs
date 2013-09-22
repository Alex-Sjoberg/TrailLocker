/*Andrew Smith
 * Byrant Sell*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TrailLocker.Models;

namespace TrailLocker.Controllers
{
    public class TripController : Controller
    {
        
        // GET: /Trip/Trips
        // Routed to by GET: /Trip/
        public ActionResult Trips()
        {
            return View(CreateTrips());
        }

        //Gets view for adding trip
        //GET: /Trip/AddTrip
        public ActionResult AddTrip()
        {
            return View();
        }
        
        // POST: /Trip/AddTrip
        [HttpPost]
        public ActionResult AddTrip(TripModel trip)
        {
            Console.Out.Write(trip.DestinationName);
            return RedirectToAction("Trips");
        }

       

        // POST: /Trip/EditTrip
        [HttpPost]
        public ActionResult EditTrip()
        {
            return View();
        }

        // POST: /Trip/DeleteTrip
        [HttpPost]
        public ActionResult DeleteTrip()
        {
            return View();
        }

        public List<TripModel> CreateTrips()
        {
            List<TripModel> tripsList = new List<TripModel>();
            tripsList.Add(new TripModel() { TripName = "Fall 2012", DestinationName = "Colorado", StartYear = 2012, StartMonth = 9, StartDay = 15, EndYear = 2012, EndMonth = 9, EndDay = 19 });
            tripsList.Add(new TripModel() { TripName = "Fall 2013", DestinationName = "Florida", StartYear = 2013, StartMonth = 10, StartDay = 18, EndYear = 2013, EndMonth = 10, EndDay = 20 });
            tripsList.Add(new TripModel() { TripName = "Summer 2013", DestinationName = "Egypt", StartYear = 2013, StartMonth = 6, StartDay = 15, EndYear = 2013, EndMonth = 6, EndDay = 19 });

            return tripsList;
        }

    }
}