using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;

namespace TrailLocker.Models.Entities
{
    public enum EquipmentCategory
    {
        General         = 0x00000000,
        Backpack        = 0x00000001,
        Perishable      = 0x00000002,
        Expendable      = 0x00000003,
        Tent            = 0x00000004,
        SleepingBag     = 0x00000005,
    }

    [Table(Name = "Equipment")]
    [InheritanceMapping(Code = EquipmentCategory.General, Type = typeof(GeneralEquipment), IsDefault = true)]
    [InheritanceMapping(Code = EquipmentCategory.Backpack, Type = typeof(BackpackEquipment))]
    [InheritanceMapping(Code = EquipmentCategory.Perishable, Type = typeof(PerishableEquipment))]
    [InheritanceMapping(Code = EquipmentCategory.Expendable, Type = typeof(ExpendableEquipment))]
    [InheritanceMapping(Code = EquipmentCategory.Tent, Type = typeof(TentEquipment))]
    [InheritanceMapping(Code = EquipmentCategory.SleepingBag, Type = typeof(SleepingBagEquipment))]
    public class Equipment
    {
        #region LINQ to SQL

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public Int32 EquipmentID { get; set; }

        [Column]
        public String Name { get; set; }

        [Column(IsDiscriminator = true)]
        public EquipmentCategory Category { get; set; }

        [Column]
        public Double Weight { get; set; }

        [Column]
        public String Location { get; set; }

        [Column]
        public Boolean IsDefault { get; set; }

        #endregion

        public Equipment()
        {

        }
    }

    /// <summary>
    /// A general piece of equipment.  No specific behavior defined.
    /// </summary>
    public class GeneralEquipment : Equipment
    {
        public GeneralEquipment()
            : base ()
        { }
    }

    /// <summary>
    /// A backpack that has a carrying capacity.
    /// </summary>
    public class BackpackEquipment : Equipment
    {
        [Column]
        public Double CarryingCapacity { get; set; }

        public BackpackEquipment()
            : base()
        { }
    }

    /// <summary>
    /// Equipment that will go bad (such as food) and thus has an expiration date.
    /// </summary>
    public class PerishableEquipment : Equipment
    {
        [Column]
        public DateTime ExpireDate { get; set; }

        public PerishableEquipment()
            : base()
        { }
    }

    /// <summary>
    /// Equipment that is only good for so many uses (such as a water filter) and thus has a certain number of uses remaining.
    /// </summary>
    public class ExpendableEquipment : Equipment
    {
        [Column]
        public Int32 UsesRemaining { get; set; }

        public ExpendableEquipment()
            : base()
        { }
    }

    /// <summary>
    /// Equipment that has sleeping capacity.
    /// </summary>
    public class TentEquipment : Equipment
    {
        [Column]
        public Int32 SleepingCapacity { get; set; }

        public TentEquipment()
            : base()
        { }
    }

    /// <summary>
    /// Equipment that has a minimum temperature.
    /// </summary>
    public class SleepingBagEquipment : Equipment
    {
        [Column]
        public Double MinimumTemperature { get; set; }

        public SleepingBagEquipment()
            : base()
        { } 
    }

}