using HSCFiscalRegistrar.DTO.Errors;
using HSCFiscalRegistrar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSCFiscalRegistrar.Helpers
{
    public class TokenValidationHelper
    {
        private readonly ApplicationContext _context;
        public TokenValidationHelper(ApplicationContext context)
        {
            _context = context;
        }


        //public bool TokenChecking(object request)
        //{
        //    if (_context.Users.FirstOrDefault(u => u.UserToken == request.Token) != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }    
        //}
    }
}
