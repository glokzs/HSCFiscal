﻿using HSCFiscalRegistrar.DTO.Auth;

namespace HSCFiscalRegistrar.DTO.TokenDto
{
    public class WrapperToken
    {
        public Data Data { get; set; }
        public override string ToString()
        {
            return $"{Data}";
        }
    }
}