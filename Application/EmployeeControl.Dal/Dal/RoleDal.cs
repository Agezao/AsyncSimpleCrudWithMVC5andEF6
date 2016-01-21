using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeControl.Dal.Dal
{
    public class RoleDal : IDal<Role>
    {
        public void Delete(int id)
        {
            using (var dbContext = new db_EmployeesEntities())
            {
                Role role = (Role)dbContext.Role.Where(r => r.Id == id).First();
                dbContext.Role.Remove(role);

                dbContext.SaveChanges();
            }
        }

        public Role Get(int id)
        {
            using (var dbContext = new db_EmployeesEntities()) {
                var query = (from r in dbContext.Role
                             where r.Id == id
                             select new
                             {
                                 r.Id,
                                 r.Name
                             }).First();

                if (query != null)
                {
                    return new Role {
                        Id = query.Id,
                        Name = query.Name
                    };
                }

                return null;
            }
        }

        public IList<Role> GetAll()
        {
            using (var dbContext = new db_EmployeesEntities())
            {
                var query = (from r in dbContext.Role
                             select new
                             {
                                 r.Id,
                                 r.Name
                             });

                if (query != null)
                {
                    var results = new List<Role>();
                    query.ToList().ForEach(role => {
                        results.Add(new Role
                        {
                            Id = role.Id,
                            Name = role.Name
                        });
                    });
                    return results;
                }
                return null;
            }
        }

        public IList<Role> GetBy(Role dto)
        {
            using (var dbContext = new db_EmployeesEntities())
            {
                var query = (from r in dbContext.Role
                             where r.Id == dto.Id
                             && r.Name == dto.Name
                             select new
                             {
                                 r.Id,
                                 r.Name
                             });

                if (query != null)
                {
                    var results = new List<Role>();
                    query.ToList().ForEach(role => {
                        results.Add(new Role
                        {
                            Id = role.Id,
                            Name = role.Name
                        });
                    });
                    return results;
                }
                return null;
            }
        }

        public Role Insert(Role dto)
        {
            using (var dbContext = new db_EmployeesEntities())
            {
                dbContext.Role.Add(dto);
                dbContext.SaveChanges();

                return dto;
            }
        }

        public Role Update(Role dto)
        {
            using (var dbContext = new db_EmployeesEntities())
            {
                dbContext.Role.Attach(dto);
                var entry = dbContext.Entry(dto);
                entry.Property(e => e.Name).IsModified = true;
                dbContext.SaveChanges();

                return dto;
            }
        }
    }
}
