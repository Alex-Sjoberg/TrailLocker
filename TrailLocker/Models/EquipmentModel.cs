using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace TrailLocker.Models
{

    public enum EquipmentCategory
    {
        General     = 0x00000000,
        Backpack    = 0x00000001,
        Perishable  = 0x00000002,
        Expendable  = 0x00000003,
        Tent        = 0x00000004,
        SleepingBag = 0x00000005,
    }

    //public enum EquipmentRating
    [Serializable()]
    public class EquipmentModel : ISerializable
    {
        public Int32 EquipmentID { get; set; }
        public String Name { get; set; }
        public EquipmentCategory Category { get; set; }
        public Double Weight { get; set; }
        public String Location { get; set; }
        public Int32 Quantity { get; set; }
        //is the item in the defualt equipment set?
        public bool inDefault { get; set; }
        //is the item in the backpack?
        public bool inBackpack { get; set; }

        public EquipmentModel()
        {
            EquipmentID = 0;
            Name = null;
            Category = EquipmentCategory.General;
            Weight = 0;
            Location = null;
            inDefault = false;
            inBackpack = false;
        }

        public EquipmentModel(SerializationInfo info, StreamingContext ctxt)
        {
            this.EquipmentID = (int)info.GetValue("EquipmentID", typeof(int));
            this.Name = (String)info.GetValue("Name", typeof(String));
            this.Category = (EquipmentCategory)info.GetValue("Category", typeof(EquipmentCategory));
            this.Weight = (double)info.GetValue("Weight", typeof(double));
            this.Location = (String)info.GetValue("Location", typeof(String));
            this.inDefault = (bool)info.GetValue("inDefault", typeof(bool));
            this.inBackpack = (bool)info.GetValue("inBackpack", typeof(bool));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("EquipmentID", EquipmentID);
            info.AddValue("Name", Name);
            info.AddValue("Category", Category);
            info.AddValue("Weight", Weight);
            info.AddValue("Location", Location);
            info.AddValue("inDefault", inDefault);
            info.AddValue("inBackpack", inBackpack);
        }
    }

    // DestinationImages
    // Destiation Coordinates
    // 

    /// <summary>
    /// A general piece of equipment. No specific behaviour defined.
    /// </summary>
    public class GeneralEquipmentModel : EquipmentModel
    {
        //TrailLocker.Models.
    }

    public class BackpackEquipmentModel : EquipmentModel
    {
        public Double Capacity { get; set; }
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