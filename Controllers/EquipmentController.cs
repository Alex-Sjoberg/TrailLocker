using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrailLocker.Models;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TrailLocker.Controllers
{
    public class EquipmentController : Controller
    {
        List<EquipmentModel> equipmentRepository;
        List<EquipmentModel> defaultRepository;
        BinaryFormatter bformatter = new BinaryFormatter();
        public String equipmentFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\equipmentRepository.txt";
        public String defaultFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\defualtRepository.txt";

        //
        // GET: /Equipment/
        public ActionResult Index()
        {
            equipmentRepository = readList(equipmentFile, equipmentRepository);
            return View(equipmentRepository.AsQueryable());
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
            equipmentRepository = readList(equipmentFile, equipmentRepository);
            equipmentModel.EquipmentID = equipmentRepository.Count;
            equipmentRepository.Add(equipmentModel);
            writeList(equipmentFile, equipmentRepository);
            return RedirectToAction("Index");
        }

        //
        // GET: /Home/Default/5
        public ActionResult Default(int EquipmentID = 0)
        {
            equipmentRepository = readList(equipmentFile, equipmentRepository);
            defaultRepository = readList(defaultFile, defaultRepository);
            EquipmentModel equipmentModel = equipmentRepository.Find(items => items.EquipmentID == EquipmentID);
            if (equipmentModel == null)
            {
                return HttpNotFound();
            }
            defaultRepository.Add(equipmentModel);
            writeList(defaultFile, defaultRepository);
            return View(defaultRepository.AsQueryable());
        }

        //
        // GET: /Home/Edit/5
        public ActionResult Edit(int EquipmentID = 0)
        {
            equipmentRepository = readList(equipmentFile, equipmentRepository);
            EquipmentModel equipmentModel = equipmentRepository.Find(items => items.EquipmentID == EquipmentID);
            if (equipmentModel == null)
            {
                return HttpNotFound();
            }
            return View(equipmentModel);
        }

        //
        // POST: /Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EquipmentModel equipmentModel)
        {
            equipmentRepository = readList(equipmentFile, equipmentRepository);
            equipmentRepository.RemoveAll(items => items.EquipmentID == equipmentModel.EquipmentID);
            equipmentRepository.Add(equipmentModel);
            writeList(equipmentFile, equipmentRepository);
            return RedirectToAction("Index");
        }

        //
        // GET: /Home/Delete/5
        public ActionResult Delete(int EquipmentID = 0)
        {
            equipmentRepository = readList(equipmentFile, equipmentRepository);
            equipmentRepository.RemoveAll(items => items.EquipmentID == EquipmentID);
            writeList(equipmentFile, equipmentRepository);
            return RedirectToAction("Index");
        }



        // GET: /Equipment/search
        public ActionResult Search(EquipmentSearchModel searchParams)
        {
            //populateEquipmentRepository();
            IQueryable<EquipmentModel> CompleteLocker = readList(equipmentFile, equipmentRepository).AsQueryable();

            //IQueryable<EquipmentModel> CompleteLocker = CreateEquipment();

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

            equipment.Add(new EquipmentModel() { Name = "Sleeping Bag", Weight = 2.0, Category = EquipmentCategory.Other, EquipmentID = 1 });
            equipment.Add(new EquipmentModel() { Name = "Pizza", Weight = 120, Category = EquipmentCategory.Perishable, EquipmentID = 2 });
            equipment.Add(new EquipmentModel() { Name = "Water Bottle", Weight = 10, Category = EquipmentCategory.Expendable, EquipmentID = 3 });
            equipment.Add(new EquipmentModel() { Name = "Backpack", Weight = 50, Category = EquipmentCategory.Backpack, EquipmentID = 4 });
            equipment.Add(new EquipmentModel() { Name = "Chips", Weight = 5, Category = EquipmentCategory.Perishable, EquipmentID = 5 });

            return equipment.AsQueryable();
        }

        private void populateEquipmentRepository()
        {
            equipmentRepository = new List<EquipmentModel>();
            equipmentRepository.Add(new EquipmentModel() { Name = "Sleeping Bag", Weight = 2.0, Category = EquipmentCategory.Other, EquipmentID = 1 });
            equipmentRepository.Add(new EquipmentModel() { Name = "Pizza", Weight = 120, Category = EquipmentCategory.Perishable, EquipmentID = 2 });
            equipmentRepository.Add(new EquipmentModel() { Name = "Water Bottle", Weight = 10, Category = EquipmentCategory.Expendable, EquipmentID = 3 });
            equipmentRepository.Add(new EquipmentModel() { Name = "Backpack", Weight = 50, Category = EquipmentCategory.Backpack, EquipmentID = 4 });
            equipmentRepository.Add(new EquipmentModel() { Name = "Chips", Weight = 5, Category = EquipmentCategory.Perishable, EquipmentID = 5 });
            writeList(equipmentFile, equipmentRepository);
        }

        private List<EquipmentModel> readList(String filename, List<EquipmentModel> repository)
        {
            if (!System.IO.File.Exists(filename))
            {
                repository = new List<EquipmentModel>();
            }
            //read equipmentRepository in from file test.txt
            else
            {
                Stream readStream = System.IO.File.Open(filename, FileMode.Open);
                repository = (List<EquipmentModel>)bformatter.Deserialize(readStream);
                readStream.Close();
            }
            return repository;
        }

        private void writeList(String filename, List<EquipmentModel> repository)
        {
            Stream writeStream = System.IO.File.Open(filename, FileMode.Create);
            bformatter.Serialize(writeStream, repository);
            writeStream.Close();
        }
    }
}
