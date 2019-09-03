using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSCFiscalRegistrar.DTO.Cashboxes
{
    public class List
    {
        public string UniqueNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public string IdentificationNumber { get; set; }
        public string Name { get; set; }
        public bool IsOffline { get; set; }
        public int CurrentStatus { get; set; }
        public int Shift { get; set; }
    }
}