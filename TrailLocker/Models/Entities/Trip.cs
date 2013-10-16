using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;

namespace TrailLocker.Models.Entities
{
    [Table(Name = "Trips")]
    public class Trip
    {
        #region LINQ to SQL

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public Int32 TripID { get; set; }

        [Column]
        public Int32 DestinationID { get; set; }

        [Column]
        public DateTime StartDate { get; set; }

        [Column]
        public DateTime EndDate { get; set; }

        #endregion
    }
}