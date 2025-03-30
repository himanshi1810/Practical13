using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task2.Models;
using Task2.ViewModels;

namespace Task2.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Designation);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,MiddleName,LastName,DOB,MobileNumber,Address,Salary,DesignationId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Name", employee.DesignationId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Name", employee.DesignationId);
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,MiddleName,LastName,DOB,MobileNumber,Address,Salary,DesignationId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "Name", employee.DesignationId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Employee Details View 
        public ActionResult EmployeeDetails()
        {
            var employeeDetails = db.Employees
                 .Include(e => e.Designation)
                 .Select(e => new EmployeeDetailsViewModel
                 {
                     EmployeeId = e.Id,
                     FirstName = e.FirstName,
                     MiddleName = e.MiddleName,
                     LastName = e.LastName,
                     DesignationName = e.Designation != null ? e.Designation.Name : "Not Assigned",
                     DOB = e.DOB,
                     MobileNumber = e.MobileNumber,
                     Address = e.Address,
                     Salary = e.Salary
                 }).ToList();

            return View("EmployeeDetails", employeeDetails);
        }
        //Designation Count
        public ActionResult EmployeeCountByDesignation()
        {
            var countByDesignation = db.Designations
               .GroupJoin(db.Employees,
                   d => d.Id,
                   e => e.DesignationId,
                   (d, employees) => new DesignationEmployeeCountViewModel
                   {
                       DesignationName = d.Name,
                       EmployeeCount = employees.Count()
                   })
               .OrderByDescending(x => x.EmployeeCount)
               .ToList();

            return View("EmployeeCountByDesignation", countByDesignation);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
