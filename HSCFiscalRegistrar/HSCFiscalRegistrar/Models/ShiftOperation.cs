using HSCFiscalRegistrar.Enums;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HSCFiscalRegistrar.Models
{
    public class ShiftOperation
    {
        public string Id { get; set; }
        public OperationTypeEnum OperationType { get; set; }
        public decimal Amount { get; set; }
        public decimal Count { get; set; }
        public decimal Cash { get; set; }
        public decimal Card { get; set; }
        public string ShiftId { get; set; }
        public virtual Shift Shift { get; set; }
    }
}