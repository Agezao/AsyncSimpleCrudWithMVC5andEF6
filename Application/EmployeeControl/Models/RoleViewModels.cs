using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeControl.Dal.Dal;

namespace EmployeeControl.Models
{
    public class RoleIndexModel
    {
        public RoleListModel RoleList { get; set; }
    }

    public class RoleListModel
    {
        public List<Role> Roles { get; set; }

        public RoleListModel()
        {
            this.Roles = new List<Role>();
        }
    }
}