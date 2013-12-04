using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
//using COS340.TrailLocker.Data;
using TrailLocker.Models;

using TrailLocker.Models.Repository;
using TrailLocker.Models.Entities;

namespace TrailLocker.Controllers
{
    [Authorize]
    public class EquipmentController : Controller
    {
        Repository<Equipment> equipmentRepository;

        public EquipmentController()
        {
            equipmentRepository = new Repository<Equipment>(new DatabaseUnitOfWork());
        }

        public EquipmentController(Repository<Equipment> repo)
        {
            equipmentRepository = repo;
        }

        //
        // GET: /Equipment/

        public ActionResult Index()
        {
            return View(equipmentRepository.FindAll());
        }

        //
        // GET: /Equipment/default

        public ActionResult Default()
        {
            return View(equipmentRepository.FindBy(x => x.IsDefault == true).AsQueryable());
        }

        //
        // GET: /Equipment/DefaultRemove/5

        public ActionResult DefaultRemove(int EquipmentID = 0)
        {
            Equipment item = equipmentRepository.FindBy(x => x.EquipmentID == EquipmentID).Single();
            item.IsDefault = false;
            equipmentRepository.Commit();
            return RedirectToAction("Default");
        }

        //
        // GET: /Equipment/add

        public ActionResult Add()
        {
            return View();
        }

        //
        // POST: /Home/add

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(GeneralEquipment equipmentModel)
        {
            equipmentRepository.Add(equipmentModel);
            equipmentRepository.Commit();
            return RedirectToAction("Index");
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int EquipmentID = 0)
        {
            Equipment item = equipmentRepository.FindBy(x => x.EquipmentID == EquipmentID).Single();
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Equipment equipmentModel)
        {
            Equipment item = equipmentRepository.FindBy(x => x.EquipmentID == equipmentModel.EquipmentID).Single();
            item.EquipmentID = equipmentModel.EquipmentID;
            item.Category = equipmentModel.Category;
            item.Name = equipmentModel.Name;
            item.Weight = equipmentModel.Weight;
            item.Location = equipmentModel.Location;
            item.IsDefault = equipmentModel.IsDefault;
            equipmentRepository.Commit();
            return RedirectToAction("Index");
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int EquipmentID = 0)
        {
            Equipment item = equipmentRepository.FindBy(x => x.EquipmentID == EquipmentID).Single();
            equipmentRepository.Remove(item);
            equipmentRepository.Commit();
            return RedirectToAction("Index");
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

            //equipment.Add(new EquipmentModel(){Name = "Sleeping Bag", Weight = 2.0, Category = EquipmentCategory.Other, EquipmentID = 1});
            //equipment.Add(new EquipmentModel(){Name = "Pizza", Weight = 120, Category = EquipmentCategory.Perishable, EquipmentID = 2});
            //equipment.Add(new EquipmentModel(){Name = "Water Bottle", Weight = 10, Category = EquipmentCategory.Expendable, EquipmentID = 3});
            //equipment.Add(new EquipmentModel(){Name = "Backpack", Weight = 50, Category = EquipmentCategory.Backpack, EquipmentID = 4});
            //equipment.Add(new EquipmentModel() { Name = "Chips", Weight = 5, Category = EquipmentCategory.Perishable, EquipmentID = 5 });

            return equipment.AsQueryable();
        }
    }
}
