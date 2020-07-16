using AspNetCoreMyExersice.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMyExcersice.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee(){Id=1,Name="Deep",Email="Deepughreja@gmail.com"},
                new Employee(){Id=2,Name="Jayesh",Email="Jayesh@gmail.com"},
                new Employee(){Id=3,Name="Chandan",Email="Chandan@gmail.com"},
                new Employee(){Id=4,Name="Tejas",Email="Tejas@gmail.com"}
            };
        }

        public Employee Add(Employee emp)
        {
            throw new NotImplementedException();
        }

        public Employee Delete(int id)
        {
            var emp = _employeeList.Where(a => a.Id == id).FirstOrDefault();
            _employeeList.Remove(emp);

            return emp;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.Where(a => a.Id == 1).FirstOrDefault();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeList;
        }

        public Employee Update(Employee empChanges)
        {
            var updatedEmp = _employeeList.Where(a => a.Id == empChanges.Id).FirstOrDefault();
            updatedEmp.Name = empChanges.Name;
            updatedEmp.Email = empChanges.Email;
            return updatedEmp;
        }
    }
}
