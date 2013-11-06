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

        //
        // GET: /Equipment/

        public ActionResult Index()
        {
            //equipmentRepository.readData();
            return View(equipmentRepository.FindAll());
        }

        //
        // GET: /Equipment/default

        public ActionResult Default()
        {
            //equipmentRepository.readData();
            //return View(equipmentRepository.FindBy(x => x.inDefault == true));
            return View(equipmentRepository.FindBy(x => x.IsDefault == true));
        }

        //
        // GET: /Equipment/DefaultRemove/5

        public ActionResult DefaultRemove(int EquipmentID = 0)
        {
            //equipmentRepository.readData();
            //EquipmentModel item = equipmentRepository.FindBy(x => x.EquipmentID == EquipmentID).Single();
            //item.inDefault = false;
            //equipmentRepository.Commit();
            return RedirectToAction("Default");
        }

        //
        // GET: /Equipment/backpack

        //public ActionResult Backpack()
        //{
        //    //equipmentRepository.readData();
        //    //return View(equipmentRepository.FindBy(x => x.inBackpack == true));
        //    return View();
        //}

        //
        // GET: /Equipment/BackpackRemove/5

        public ActionResult BackpackRemove(int EquipmentID = 0)
        {
            //equipmentRepository.readData();
            //EquipmentModel item = equipmentRepository.FindBy(x => x.EquipmentID == EquipmentID).Single();
            //item.inBackpack = false;
            //equipmentRepository.Commit();
            return RedirectToAction("Backpack");
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
        public ActionResult Add(EquipmentModel equipmentModel)
        {
            //equipmentRepository.readData();
            //equipmentRepository.Add(equipmentModel);
            //equipmentRepository.Commit();
            return RedirectToAction("Index");
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int EquipmentID = 0)
        {
            //equipmentRepository.readData();
            //EquipmentModel equipmentModel = equipmentRepository.FindBy(x => x.EquipmentID == EquipmentID).Single();
            //if (equipmentModel == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(equipmentModel);
            return View();
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EquipmentModel equipmentModel)
        {
            //equipmentRepository.readData();
            //EquipmentModel removeItem = equipmentRepository.FindBy(x => x.EquipmentID == equipmentModel.EquipmentID).Single();
            //equipmentRepository.Remove(removeItem);
            //equipmentRepository.Add(equipmentModel);
            //equipmentRepository.Commit();
            return RedirectToAction("Index");
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int EquipmentID = 0)
        {
            //equipmentRepository.readData();
            //EquipmentModel removeItem = equipmentRepository.FindBy(x => x.EquipmentID == EquipmentID).Single();
            //System.Diagnostics.Debug.Print(removeItem.ToString());
            //equipmentRepository.Remove(removeItem);
            //equipmentRepository.Commit();
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
