using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspNetCoreMyExersice.DTO.Utilities
{
    public class ValidEmailDomailAttribute : ValidationAttribute
    {
        private readonly string allowedDomain;

        public ValidEmailDomailAttribute(string allowedDomain)
        {
            this.allowedDomain = allowedDomain;
        }

        public override bool IsValid(object value)
        {
            string[] domainStr = value.ToString().Split("@");
            return domainStr[1].ToUpper() == allowedDomain.ToString().ToUpper();
        }
    }
}
