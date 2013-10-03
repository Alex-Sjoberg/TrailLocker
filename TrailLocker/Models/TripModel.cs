/*Andrew Smith
 * Bryant Sell*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace TrailLocker.Models
{
    public class TripModel
    {
        public String TripName { get; set; }
        public String DestinationName { get; set; }
        
        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
        public Int32 StartYear { get; set; }
        public Int32 StartMonth { get; set; }
        public Int32 StartDay { get; set; }
        public Int32 EndYear { get; set; }
        public Int32 EndMonth { get; set; }
        public Int32 EndDay { get; set; }


       /* 
        public Trip(String tripName, String destinationName, int startYear, int startMonth, int startDay, int endYear, int endMonth, int endDay)
        {
            this.TripName = tripName;
            this.DestinationName = destinationName;
            this.StartDate = new DateTime(startYear,startMonth,startDay);
            this.EndDate = new DateTime(endYear, endMonth, endDay);
            this.startYear = startYear;
            this.startMonth = startMonth;
            this.startDay = startYear;
            this.endYear = endYear;
            this.endMonth = endMonth;
            this.endDay = endDay;
            
        }

        public String toString()
        {
            return this.TripName;
        }*/
    }
}