using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrailLocker.Models
{
    public class EquipmentSearchModel
    {
        public String Name { get; set; }
        public EquipmentCategory? Category { get; set; }
        public Double? MinWeight { get; set; }
        public Double? MaxWeight { get; set; }
    }
}