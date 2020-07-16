using AspNetCoreMyExersice.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMyExcersice.Models
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Get Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee GetEmployee(int id);

        /// <summary>
        /// GetEmployees
        /// </summary>
        /// <returns></returns>
        IEnumerable<Employee> GetEmployees();

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        Employee Add(Employee emp);
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        Employee Update(Employee emp);
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        Employee Delete(int empId);



    }
}
