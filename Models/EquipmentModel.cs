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
        Other       = 0x00000004
    }

    //public enum EquipmentRating

    public class EquipmentModel
    {
        public Int32 EquipmentID { get; set; }
        public String Name { get; set; }
        public EquipmentCategory Category { get; set; }
        public Double Weight { get; set; }
        public String Location { get; set; }
    }
}