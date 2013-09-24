using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TrailLocker.Models
{
    public enum EquipmentCategory
    {
        Backpack = 0x00000001,
        Perishable = 0x00000002,
        Expendable = 0x00000003,
        Tent = 0x00000004,
        SleepingBag = 0x00000005,
        Other = 0x00000006
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

        //no argument constructor for ISerializable functionality
        public EquipmentModel()
        {
            EquipmentID = 0;
            Name = null;
            Category = EquipmentCategory.Other;
            Weight = 0;
            Location = null;
            Quantity = 0;
        }

        //serialization function to read from file
        public EquipmentModel(SerializationInfo info, StreamingContext ctxt)
        {
            this.EquipmentID = (Int32)info.GetValue("EquipmentID", typeof(Int32));
            this.Name = (String)info.GetValue("Name", typeof(String));
            this.Category = (EquipmentCategory)info.GetValue("Category", typeof(EquipmentCategory));
            this.Weight = (Double)info.GetValue("Weight", typeof(Double));
            this.Location = (String)info.GetValue("Location", typeof(String));
            this.Quantity = (Int32)info.GetValue("Quantity", typeof(Int32));
        }

        //serialization function to write to file
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("EquipmentID", EquipmentID);
            info.AddValue("Name", Name);
            info.AddValue("Category", Category);
            info.AddValue("Weight", Weight);
            info.AddValue("Location", Location);
            info.AddValue("Quantity", Quantity);
        }
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