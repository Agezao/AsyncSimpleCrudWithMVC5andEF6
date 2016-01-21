using EmployeeControl.Dal.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeControl.Dal.Controller
{
    public class EmployeeController : IController<Employee>
    {
        public void Delete(int id)
        {
            new EmployeeDal().Delete(id);
        }

        public Employee Get(int id)
        {
            return new EmployeeDal().Get(id);
        }

        public IList<Employee> GetAll()
        {
            return new EmployeeDal().GetAll();
        }

        public IList<Employee> GetBy(Employee dto)
        {
            return new EmployeeDal().GetBy(dto);
        }

        public Employee Insert(Employee dto)
        {
            return new EmployeeDal().Insert(dto);
        }

        public Employee Update(Employee dto)
        {
            return new EmployeeDal().Update(dto);
        }
    }
}
