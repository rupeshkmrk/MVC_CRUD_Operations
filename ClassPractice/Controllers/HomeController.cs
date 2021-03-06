﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCClassDemo.Models;
namespace MVCClassDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        static EmployeeDB empDb = new EmployeeDB();
        public ActionResult Index()
        {
            
            return RedirectToAction("All");
        }


        public ActionResult All()
        {

            // EmployeeDB db = new EmployeeDB();
            var emp = empDb.GetEmployees();
            //System.Diagnostics.Debug.WriteLine(emp);
            //foreach (Employee emp1 in emp)
            //{
            //    System.Diagnostics.Debug.WriteLine(emp1.name);
            //}
            return View(emp);

        }
        public ActionResult Edit(string id)
        {
            int i = int.Parse(id);
            List<Employee> emp = empDb.GetEmployees();
            var model = emp.Find(e => e.id == i);
            return View(model);
            //return "Edit Page Works";
        }
        [HttpPost]
        public ActionResult Edit(Employee updated)
        {
            empDb.UpdateEmployee(updated);
            return RedirectToAction("All");
        }
        public string Update(string str)
        {
            return "Update Called";
        }
        public ActionResult Delete(string id)
        {
            int i = int.Parse(id);
            empDb.DeleteEmployee(i);
            List<Employee> emp = empDb.GetEmployees();
            return RedirectToAction("All");//View(emp);
        }
        [HttpGet]
        public ActionResult Add(Employee employee)
        {
            return View();
            //empDb.AddEmployee(employee);
            //return RedirectToAction("All");
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            empDb.AddEmployee(employee);
            return RedirectToAction("All");
        }

    }
}
