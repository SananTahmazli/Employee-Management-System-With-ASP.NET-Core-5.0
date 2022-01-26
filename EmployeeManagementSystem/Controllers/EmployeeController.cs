using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> employeeList = _db.Employees;
            return View(employeeList);
        }

        [HttpGet]
        public IActionResult AddNewEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewEmployee(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(emp);
                _db.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }
            return View(emp);
        }

        [HttpGet]
        public IActionResult EditEmployee(int? ID)
        {
            var employee = _db.Employees.Find(ID);
            return View(employee);
        }

        [HttpPost]
        public IActionResult EditEmployee(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Update(emp);
                _db.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }
            return View(emp);
        }

        [HttpGet]
        public IActionResult RemoveEmployee(int? ID)
        {
            var employee = _db.Employees.Find(ID);
            return View(employee);
        }

        [HttpPost]
        public IActionResult RemoveEmployeePost(int? ID)
        {
            var employee = _db.Employees.Find(ID);
            _db.Employees.Remove(employee);
            _db.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }

        [HttpGet]
        public IActionResult DetailsOfEmployee(int? ID)
        {
            var employee = _db.Employees.Find(ID);
            return View(employee);
        }

        [HttpPost]
        public IActionResult SearchEmployee(string empData)
        {
            if (empData == null)
            {
                return RedirectToAction("Index", "Employee");
            }
            return View("Index", _db.Employees.Where(p => p.NameAndSurname.Contains(empData)).ToList());
        }
    }
}
