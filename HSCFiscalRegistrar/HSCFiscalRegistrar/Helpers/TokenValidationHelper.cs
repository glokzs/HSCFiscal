using HSCFiscalRegistrar.DTO.Errors;
using HSCFiscalRegistrar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HSCFiscalRegistrar.DTO.TokenValid;

namespace HSCFiscalRegistrar.Helpers
{
    public class TokenValidationHelper
    {
        private readonly ApplicationContext _context;

        public TokenValidationHelper(ApplicationContext context)
        {
            _context = context;
        }
        
        public bool TokenChecking(UserDTO dto)
        {
            User user = _context.Users.FirstOrDefault(u => u.Email == dto.Email);
            return user != null && (dto.Token != null && user.UserToken.ToString() == dto.Token);
        }
    }
}