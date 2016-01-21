using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeControl.Dal.Dal
{
    public class EmployeeDal : IDal<Employee>
    {
        public void Delete(int id)
        {
            using (var dbContext = new db_EmployeesEntities())
            {
                Employee employee = (Employee)dbContext.Employee.Where(e => e.Id == id).First();
                dbContext.Employee.Remove(employee);

                dbContext.SaveChanges();
            }
        }

        public Employee Get(int id)
        {
            using (var dbContext = new db_EmployeesEntities())
            {
                var query = (from e in dbContext.Employee
                             where e.Id == id
                             select new
                             {
                                 e.Id,
                                 e.Name,
                                 e.IdRole,
                                 e.Role
                             }).First();

                if (query != null)
                {
                    return new Employee
                    {
                        Id = query.Id,
                        Name = query.Name,
                        IdRole = query.IdRole,
                        Role = query.Role
                    };
                }

                return null;
            }
        }

        public IList<Employee> GetAll()
        {
            using (var dbContext = new db_EmployeesEntities())
            {
                var query = (from e in dbContext.Employee
                             select new
                             {
                                 e.Id,
                                 e.IdRole,
                                 e.Name,
                                 e.Role
                             });

                if (query != null)
                {
                    var results = new List<Employee>();
                    query.ToList().ForEach(employee => {
                        results.Add(new Employee
                        {
                            Id = employee.Id,
                            Name = employee.Name,
                            IdRole = employee.IdRole,
                            Role = employee.Role
                        });
                    });
                    return results;
                }
                return null;
            }
        }

        public IList<Employee> GetBy(Employee dto)
        {
            using (var dbContext = new db_EmployeesEntities())
            {
                var query = (from e in dbContext.Employee
                             where e.Id == dto.Id
                             && e.Name == dto.Name
                             && e.IdRole == dto.IdRole
                             select new
                             {
                                 e.Id,
                                 e.Name,
                                 e.IdRole,
                                 e.Role
                             });

                if (query != null)
                {
                    var results = new List<Employee>();
                    query.ToList().ForEach(employee => {
                        results.Add(new Employee
                        {
                            Id = employee.Id,
                            Name = employee.Name,
                            IdRole = employee.IdRole,
                            Role = employee.Role
                        });
                    });
                    return results;
                }
                return null;
            }
        }

        public Employee Insert(Employee dto)
        {
            using (var dbContext = new db_EmployeesEntities())
            {
                dbContext.Employee.Add(dto);
                dbContext.SaveChanges();

                return dto;
            }
        }

        public Employee Update(Employee dto)
        {
            using (var dbContext = new db_EmployeesEntities())
            {
                dbContext.Employee.Attach(dto);
                var entry = dbContext.Entry(dto);
                entry.Property(e => e.Name).IsModified = true;
                entry.Property(e => e.IdRole).IsModified = true;
                dbContext.SaveChanges();

                return dto;
            }
        }
    }
}
