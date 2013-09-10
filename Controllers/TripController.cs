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

        // POST: /Trip/AddTrip
        [HttpPost]
        public ActionResult AddTrip()
        {
            return View();
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

    }
}