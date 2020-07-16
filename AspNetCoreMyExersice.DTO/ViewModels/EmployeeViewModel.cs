using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreMyExersice.DTO.ViewModels
{
    public class EmployeeViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter valid Email")]
        public string Email { get; set; }
        /// <summary>
        /// Photo path
        /// </summary>
        public IFormFile Photo { get; set; }
    }
}
