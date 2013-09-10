using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestLocker.Models
{   
    public class Trip
    {
       
        public String TripName { get; set; }
        public String DestinationName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }


        public Trip(string destinationName)
        {
            this.DestinationName = destinationName;
        }

        public String toString()
        {
            return this.DestinationName;
        }
    }
}