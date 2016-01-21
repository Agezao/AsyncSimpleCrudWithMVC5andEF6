﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeControl.Dal.Dal
{
    public interface IDal<T>
    {
        T Get(int id);
        IList<T> GetAll();
        IList<T> GetBy(T dto);
        T Insert(T dto);
        T Update(T dto);
        void Delete(int id);
    }
}
