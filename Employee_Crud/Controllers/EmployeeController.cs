using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee_Crud.Models;
using Employee_Crud.ViewModels;

namespace Employee_Crud.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _dbContext;
        public EmployeeController()
        {
            this._dbContext = new EmployeeDbContext();
        }

        // GET: Employee
        public ActionResult Index(string option, string search)
        {
            var employeeList = this._dbContext.Employee.Include(x => x.Department).ToList();
            if (option == "Name")
            {
                return View(_dbContext.Employee.Where(x => x.EmployeeName.StartsWith(search) || search == null).ToList());
            }
            return View(employeeList);
        }
        public ActionResult Details(int? id)
        {
            Employee employee = _dbContext.Employee.Find(id);
            if (employee == null)
            {
                HttpNotFound();
            }
            return View(employee);
        }
        public ActionResult AddEmployees()
        {
            var employeeViewModel = new EmployeeViewModel()
            {
                Department = this._dbContext.Department.ToList(),
                Employee = new Employee()
            };
            return View("EmployeeForm", employeeViewModel);
        }
        public ActionResult Edit(int id)
        {
            var employees = this._dbContext.Employee.FirstOrDefault(x => x.EmployeeId == id);
            var department = this._dbContext.Department.ToList();

            var viewModel = new EmployeeViewModel()
            {
                Department = department,
                Employee = employees
            };
            return View("EmployeeForm", viewModel);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddEmployees", "Employee");
            }

            if (employee.EmployeeId == 0)
                this._dbContext.Employee.Add(employee);

            else
            {
                var employeesDb = this._dbContext.Employee.FirstOrDefault(x => x.EmployeeId == employee.EmployeeId);
                employeesDb.EmployeeName = employee.EmployeeName;
                employeesDb.EmployeePhone = employee.EmployeePhone;
                employeesDb.EmployeeGender = employee.EmployeeGender;
                employeesDb.Birthday = employee.Birthday;
                employeesDb.DepartmentId = employee.DepartmentId;
            }

            this._dbContext.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }
        public ActionResult Delete(int id)
        {
            var employeeDb = this._dbContext.Employee.FirstOrDefault(x => x.EmployeeId == id);
            this._dbContext.Employee.Remove(employeeDb);
            this._dbContext.SaveChanges();

            return RedirectToAction("Index", "Employee");
        }


    }
}