using System.Collections.Generic;

namespace HSCFiscalRegistrar.DTO.XReport.KkmResponce
{
    public class OperationTypeSummaryApiModel
    {
        public List<PaymentsByTypesApiModel> PaymentsByTypesApiModel { get; set; }
        public decimal Discount { get; set; }
        public decimal Markup { get; set; }
        public decimal Taken { get; set; }
        public decimal Change { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public decimal VAT { get; set; }
    }
}