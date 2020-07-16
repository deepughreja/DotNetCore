using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreMyExersice.DTO.ViewModels
{
    public class EmployeeEditViewModel : EmployeeViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ExistingPhotoPath
        /// </summary>
        public string ExistingPhotoPath { get; set; }
    }
}
