using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;
        public SQLEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }

        Employee IEmployeeRepository.Delete(int Id)
        {
            Employee employee = context.Employees.Find(Id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        Employee IEmployeeRepository.GetEmployee(int Id)
        {
            return context.Employees.Find(Id);
        }

        IEnumerable<Employee> IEmployeeRepository.GetEmployees()
        {
            return context.Employees;
        }

        Employee IEmployeeRepository.Update(Employee employeechanges)
        {
            var employee = context.Employees.Attach(employeechanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employeechanges;
        }
    }
}
