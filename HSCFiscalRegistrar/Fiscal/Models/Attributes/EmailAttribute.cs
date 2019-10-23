using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiscal.Models
{
    public class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string userName = value.ToString();
                if (userName.IndexOf("@") > 0)
                    return true;
                else
                    this.ErrorMessage = "Почта должна содержать @";
            }
            return false;
        }
    }
}
