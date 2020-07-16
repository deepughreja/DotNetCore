using AspNetCoreMyExersice.DTO.Models;
using AspNetCoreMyExersice.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreMyExcersice.Abstract.Interfaces
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
        Employee Add(EmployeeViewModel emp,string rootPath);
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        EmployeeEditViewModel Update(EmployeeEditViewModel emp, string rootPath);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        Employee Delete(int empId);

    }
}
