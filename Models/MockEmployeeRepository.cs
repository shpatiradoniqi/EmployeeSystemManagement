using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Models
{
    public class MockEmployeeRepository : IEmployeeRepository {

        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {



            _employeeList = new List<Employee>() {
                new Employee()
                {
                    Id = 1,
                    Name = "Mary",
                    Departament = Dept.HR,
                    Email = "mary@pragimtech.com"
                },
                new Employee()
                {
                    Id = 2,
                    Name = "John",
                    Departament = Dept.IT,
                    Email = "john@pragimtech.com"

                }
            };





        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;

        }

        public Employee Delete(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == id);
            if (employee!=null){
                _employeeList.Remove(employee);

            }
            return employee;

        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;

        }

        public Employee GetEmpolyee(int id)
        {
            return this._employeeList.FirstOrDefault(e => e.Id == id);
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee!=null){

                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Departament = employeeChanges.Departament;


            }
            return employee;


        }
    }
}
