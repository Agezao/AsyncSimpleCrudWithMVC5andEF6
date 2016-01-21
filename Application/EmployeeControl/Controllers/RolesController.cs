using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeControl.Dal.Controller;
using EmployeeControl.Dal.Dal;

namespace EmployeeControl.Controllers
{
    public class RolesController : Controller
    {
        private RoleController roleController = new RoleController();
        // GET: /Roles
        public ActionResult Index()
        {
            var model = new Models.RoleIndexModel();
            
            model.RoleList = new Models.RoleListModel();
            model.RoleList.Roles = roleController.GetAll().ToList();

            return View(model);
        }

        public ActionResult RoleForm() {
            return View();
        }

        public PartialViewResult RoleList()
        {
            var model = new Models.RoleListModel();
            model.Roles = roleController.GetAll().ToList();

            return PartialView(model);
        }

        // POST: /Roles/Add
        [HttpPost]
        [AllowAnonymous]
        public JsonResult AddRole(string name) {
            var viewRole = new Role {
                Name = name
            };
            var returned = roleController.Insert(viewRole);

            if(returned != null)
                return Json(new { success = true });
            return Json(new { success = false });
        }

    }
}