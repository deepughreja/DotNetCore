using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspNetCoreMyExersice.DTO.Models
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
        /// <summary>
        /// RoleId
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// Role Name
        /// </summary>
        [Required]
        public string RoleName { get; set; }
        /// <summary>
        /// Users
        /// </summary>
        public List<string> Users { get; set; }
    }
}
