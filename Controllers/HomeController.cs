using GlobleTimesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobleTimesApp.Controllers
{
    public class HomeController : Controller
    {
        Demo_LearningEntities db = new Demo_LearningEntities();
        public ActionResult Index()
        {
            var listempdata = db.tbl_Employees.ToList();
            return View(listempdata);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Employees model)
        {
            db.tbl_Employees.Add(model);
            db.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.tbl_Employees.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(tbl_Employees Model)
        {
            var data = db.tbl_Employees.Where(x => x.Id == Model.Id).FirstOrDefault();
            if (data != null)
            {
                data.FirstName = Model.FirstName;
                data.LastName = Model.LastName;
                data.Location = Model.Location;
                data.Gender = Model.Gender;
                data.Salary = Model.Salary;
                db.SaveChanges();
            }

            return RedirectToAction("index");
        }
        
        public ActionResult Detail(int id)
        {
            tbl_Employees data = db.tbl_Employees.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = db.tbl_Employees.Where(x => x.Id == id).FirstOrDefault();
            db.tbl_Employees.Remove(data);
            db.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }
    }
}