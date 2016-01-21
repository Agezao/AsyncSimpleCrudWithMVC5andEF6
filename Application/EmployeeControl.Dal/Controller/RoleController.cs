using EmployeeControl.Dal.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeControl.Dal.Controller
{
    public class RoleController : IController<Role>
    {
        public void Delete(int id)
        {
            new RoleDal().Delete(id);
        }

        public Role Get(int id)
        {
            return new RoleDal().Get(id);
        }

        public IList<Role> GetAll()
        {
            return new RoleDal().GetAll();
        }

        public IList<Role> GetBy(Role dto)
        {
            return new RoleDal().GetBy(dto);
        }

        public Role Insert(Role dto)
        {
            return new RoleDal().Insert(dto);
        }

        public Role Update(Role dto)
        {
            return new RoleDal().Update(dto);
        }
    }
}
