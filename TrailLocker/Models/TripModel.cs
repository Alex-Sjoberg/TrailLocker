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
        public Int32 TripID { get; set; }
        public String TripName { get; set; }
        public String DestinationName { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Int32 StartYear { get; set; }
        public Int32 StartMonth { get; set; }
        public Int32 StartDay { get; set; }
        public Int32 EndYear { get; set; }
        public Int32 EndMonth { get; set; }
        public Int32 EndDay { get; set; }



        public TripModel(int tripId, String tripName, String destinationName, int startYear, int startMonth, int startDay, int endYear, int endMonth, int endDay)
        {
            this.TripID = tripId;
            //this.TripName = tripName;
            this.DestinationName = destinationName;
            this.StartDate = new DateTime(startYear,startMonth,startDay);
            this.EndDate = new DateTime(endYear, endMonth, endDay);
            this.StartYear = startYear;
            this.StartMonth = startMonth;
            this.StartDay = startYear;
            this.EndYear = endYear;
            this.EndMonth = endMonth;
            this.EndDay = endDay;
            
        }

        public String toString()
        {
            return this.TripName;
        }
    }
}