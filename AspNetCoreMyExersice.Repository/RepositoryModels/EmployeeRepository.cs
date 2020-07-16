using AspNetCoreMyExcersice.Abstract.Interfaces;
using AspNetCoreMyExcersice.DataAccess.Models;
using AspNetCoreMyExersice.DTO.Models;
using AspNetCoreMyExersice.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AspNetCoreMyExersice.Repository.RepositoryModels
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;

        public EmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }


        public Employee Add(EmployeeViewModel emp, string rootPath)
        {
            Employee empObj = new Employee();
            string uniqueName = ProcessUploadedFile(emp, rootPath);
            empObj = new Employee()
            {
                Name = emp.Name,
                Email = emp.Email,
                PhotoPath = uniqueName
            };

            this.context.Employees.Add(empObj);
            this.context.SaveChanges();
            return empObj;
        }

        private static string ProcessUploadedFile(EmployeeViewModel emp, string rootPath)
        {
            string uniqueName = null;
            if (emp != null)
            {
                string uploadFolder = Path.Combine(rootPath, "images");
                uniqueName = Guid.NewGuid().ToString() + "_" + emp.Photo.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueName);
                emp.Photo.CopyTo(new FileStream(filePath, FileMode.Create));

            }
            return uniqueName;
        }

        public Employee Delete(int empId)
        {
            Employee emp = context.Employees.Find(empId);
            if (emp != null)
            {
                context.Employees.Remove(emp);
                context.SaveChanges();
            }

            return emp;
        }

        public Employee GetEmployee(int id)
        {
            return context.Employees.Find(id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees;
        }

        public EmployeeEditViewModel Update(EmployeeEditViewModel empViewModel, string rootPath)
        {
            string photoPath = string.Empty;
            if (empViewModel.Photo != null)
            {
                if (empViewModel.ExistingPhotoPath != null)
                {
                    string filePath = Path.Combine(rootPath, "/Images/", empViewModel.ExistingPhotoPath);
                    System.IO.File.Delete(filePath);
                }
                photoPath = ProcessUploadedFile(empViewModel, rootPath);
            };
            Employee dbEmployee = new Employee()
            {
                Id = empViewModel.Id,
                Name = empViewModel.Name,
                Email = empViewModel.Email,
                PhotoPath = photoPath
            };
            var employee = context.Employees.Attach(dbEmployee);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return empViewModel;
        }
    }
}
