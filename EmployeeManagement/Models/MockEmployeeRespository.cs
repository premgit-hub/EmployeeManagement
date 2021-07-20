using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRespository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRespository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() {Id = 1 , Name =  "Prem"}                
            };
        }
        public Employee GetEmployee(int Id)
        {
           return _employeeList.FirstOrDefault(e => e.Id == Id);         
        }

        Employee IEmployeeRepository.Delete(int Id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == Id);
            if (employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }

        IEnumerable<Employee> IEmployeeRepository.GetEmployee()
        {
            throw new NotImplementedException();
        }

        Employee IEmployeeRepository.Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
            }
            return employee;
        }
    }
}
