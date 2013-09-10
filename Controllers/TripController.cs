using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrailLocker.Controllers
{
    public class TripController : Controller
    {
        //
        // GET: /Trip/

        public ActionResult Index()
        {
            return View();
        }

        // PUT: /Trip/AddTrip
        [HttpPut]
        public ActionResult AddTrip(string TripName, string DestinationName, DateTime StartDate, DateTime EndDate, double Latitude, double Longitude)
        {
            return View();
        }

    }
}
