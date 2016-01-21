using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeControl.Dal.Dal;

namespace EmployeeControl.Models
{
    public class EmployeeIndexModel
    {
        public EmployeeFormModel EmployeeForm { get; set; }

        public EmployeeListModel EmployeeList { get; set; }
    }

    public class EmployeeFormModel
    {
        public List<Role> Roles { get; set; }

        public EmployeeFormModel()
        {
            this.Roles = new List<Role>();
        }
    }

    public class EmployeeListModel
    {
        public List<Employee> Employees { get; set; }

        public EmployeeListModel()
        {
            this.Employees = new List<Employee>();
        }
    }
}