using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;

using TrailLocker.Models.Entities;

namespace TrailLocker.Models.Repository
{
    [Database(Name = "TrailLocker")]
    public class TrailLockerDataContext : DataContext
    {
        //public Table<Destination> Destinations { get; set; }
        public Table<Equipment> Equipment;
        //public Table<EquipmentImage> EquipmentImages { get; set; }
        //public Table<Friendship> Friendships { get; set; }
        //public Table<Locker> Lockers { get; set; }
        //public Table<TripEquipment> TripEquipment { get; set; }
        public Table<Trip> Trips;
        //public Table<User> Users { get; set; }
        //public Table<UserTrip> UserTrips { get; set; }

        public TrailLockerDataContext()
            : base(System.Configuration.ConfigurationManager.ConnectionStrings["TrailLocker"].ConnectionString)
        { }
    }
}