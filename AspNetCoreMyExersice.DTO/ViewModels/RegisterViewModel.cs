using AspNetCoreMyExersice.DTO.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspNetCoreMyExersice.DTO.ViewModels
{
    /// <summary>
    /// Register View Model
    /// </summary>
    public class RegisterViewModel
    {
        [Required]
        [Display(Name ="Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "{0} is not valid")]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        [ValidEmailDomailAttribute(allowedDomain:"gmail.com",ErrorMessage ="Email Domail must be gmail.com")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password and Confirm Password Does not Matched")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

    }
}
