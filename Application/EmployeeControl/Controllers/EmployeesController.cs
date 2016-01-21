using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeControl.Dal.Controller;
using EmployeeControl.Dal.Dal;

namespace EmployeeControl.Controllers
{
    public class EmployeesController : Controller
    {
        private RoleController roleController = new RoleController();
        private EmployeeController employeeController = new EmployeeController();
        // GET: /Employees
        public ActionResult Index()
        {
            var model = new Models.EmployeeIndexModel();
            
            model.EmployeeList = new Models.EmployeeListModel();
            model.EmployeeList.Employees = employeeController.GetAll().ToList();

            model.EmployeeForm = new Models.EmployeeFormModel();
            model.EmployeeForm.Roles = roleController.GetAll().ToList();

            return View(model);
        }

        public ActionResult EmployeeForm() {
            var model = new EmployeeControl.Models.EmployeeFormModel();
            model.Roles = roleController.GetAll().ToList();

            return View(model);
        }

        public PartialViewResult EmployeeList()
        {
            var model = new EmployeeControl.Models.EmployeeListModel();
            model.Employees = employeeController.GetAll().ToList();

            return PartialView(model);
        }

        // POST: /Employees/Add
        [HttpPost]
        [AllowAnonymous]
        public JsonResult AddEmployee(string name, int idRole) {
            var viewEmployee = new Employee {
                Name = name,
                IdRole = idRole
            };
            var returned = employeeController.Insert(viewEmployee);

            if(returned != null)
                return Json(new { success = true });
            return Json(new { success = false });
        }

    }
}