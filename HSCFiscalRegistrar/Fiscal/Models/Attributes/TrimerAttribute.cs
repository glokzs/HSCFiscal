using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiscal.Models.Attributes
{
    public class TrimerAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //try to modify text
            try
            {
                validationContext
                .ObjectType
                .GetProperty(validationContext.MemberName)
                .SetValue(validationContext.ObjectInstance, value.ToString().Trim(), null);
            }
            catch (System.Exception)
            {
            }

            //return null to make sure this attribute never say iam invalid
            return null;
        }
    }
}
