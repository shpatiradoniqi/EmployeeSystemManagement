﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Models
{
 public  interface IEmployeeRepository
    {

        Employee GetEmpolyee(int id);
        IEnumerable<Employee> GetAllEmployees();

        Employee Add(Employee employee);

        Employee Update(Employee employeeChanges);

        Employee Delete(int id);





        

        

    }
}
