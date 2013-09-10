using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TrailLocker.Models;

namespace TrailLocker.Controllers
{
    public class EquipmentController : Controller
    {


        //
        // GET: /Equipment/

        public ActionResult Index()
        {
            return View();
        }

        // GET: /Equipment/search
        public ActionResult Search(EquipmentSearchModel searchParams)
        {
            IQueryable<EquipmentModel> CompleteLocker = CreateEquipment();

            if (!String.IsNullOrEmpty(searchParams.Name))
            {
                CompleteLocker = CompleteLocker.Where(e => e.Name == searchParams.Name);
            }

            if (searchParams.Category != null)
            {
                CompleteLocker = CompleteLocker.Where(e => e.Category == searchParams.Category);
            }

            if (searchParams.MinWeight != null)
            {
                CompleteLocker = CompleteLocker.Where(e => e.Weight >= (int)searchParams.MinWeight);
            }

            if (searchParams.MaxWeight != null)
            {
                CompleteLocker = CompleteLocker.Where(e => e.Weight <= (int)searchParams.MaxWeight);
            }

            return View(CompleteLocker);
        }

        private IQueryable<EquipmentModel> CreateEquipment()
        {
            List<EquipmentModel> equipment = new List<EquipmentModel>();

            equipment.Add(new EquipmentModel(){Name = "Sleeping Bag", Weight = 2.0, Category = EquipmentCategory.Other, EquipmentID = 1});
            equipment.Add(new EquipmentModel(){Name = "Pizza", Weight = 120, Category = EquipmentCategory.Perishable, EquipmentID = 2});
            equipment.Add(new EquipmentModel(){Name = "Water Bottle", Weight = 10, Category = EquipmentCategory.Expendable, EquipmentID = 3});
            equipment.Add(new EquipmentModel(){Name = "Backpack", Weight = 50, Category = EquipmentCategory.Backpack, EquipmentID = 4});
            equipment.Add(new EquipmentModel() { Name = "Chips", Weight = 5, Category = EquipmentCategory.Perishable, EquipmentID = 5 });

            return equipment.AsQueryable();
        }
    }
}
