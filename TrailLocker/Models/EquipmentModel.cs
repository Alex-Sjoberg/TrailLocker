using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrailLocker.Models
{
    public enum EquipmentCategory
    {
        Backpack    = 0x00000001,
        Perishable  = 0x00000002,
        Expendable  = 0x00000003,
        Tent        = 0x00000004,
        SleepingBag = 0x00000005,
        Other       = 0x00000006
    }

    //public enum EquipmentRating

    public class EquipmentModel
    {
        public Int32 EquipmentID { get; set; }
        public String Name { get; set; }
        public EquipmentCategory Category { get; set; }
        public Double Weight { get; set; }
        public String Location { get; set; }
        public Int32 Quantity { get; set; }
    }

    // DestinationImages
    // Destiation Coordinates
    // 

    public class BackpackEquipmentModel : EquipmentModel
    {
        public Double Capacity { get; set; }

        //public String Size
        //{
        //    get
        //    {
        //        //if (Volume < 20.0)
        //        //{
        //        //    return "Small";
        //        //}
        //        //else if (Volume < 50.0)
        //        //{
        //        //    return "Medium";
        //        //}
        //    }
        //}
    }

    public class PerishableEquipmentModel : EquipmentModel
    {
        public DateTime ExpireDate { get; set; }
    }

    public class ExpendableEquipmentModel : EquipmentModel
    {
        public Int32 UsesRemaining { get; set; }
    }

    public class TentEquipmentModel : EquipmentModel
    {
        public Int32 SleepingCapacity { get; set; }
    }

    public class SleepingBagEquipmentModel : EquipmentModel
    {
        public Double MinimumTemperature { get; set; }
    }
}