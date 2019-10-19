using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Models.APKInfo;
using Models.Enums;

namespace HSCFiscalRegistrar.DTO.XReport.KkmResponse
{
    public class XReportKkmResponse
    {
        public Data Data { get; set; }

        public XReportKkmResponse(List<ShiftOperation> shiftOperations,
            IQueryable<Operation> operations,
            User org, Kkm kkm, Shift shift)
        {
            Data = new Data
            {
                Buy = GetOperation(shiftOperations, OperationTypeEnum.OPERATION_BUY),
                Sell = GetOperation(shiftOperations, OperationTypeEnum.OPERATION_SELL),
                ReturnBuy = GetOperation(shiftOperations, OperationTypeEnum.OPERATION_BUY_RETURN),
                ReturnSell = GetOperation(shiftOperations, OperationTypeEnum.OPERATION_SELL_RETURN),
                TaxPayerName = org.Name,
                TaxPayerVAT = org.VAT,
                TaxPayerIN = org.Inn,
                TaxPayerVATNumber = org.VATNumber,
                TaxPayerVATSeria = org.VATSeria,
                CashboxIN = kkm.DeviceId,
                CashboxSN = kkm.SerialNumber,
                CashboxRN = kkm.FnsKkmId,
                StartOn = shift.OpenDate,
                CloseOn = shift.CloseDate,
                ReportOn = DateTime.Now,
                CashierCode = org.Code,
                ShiftNumber = shift.Number,
                ControlSum = 1,
                DocumentCount = operations.Count(),
                OfflineMode = true,
                ReportNumber = 1,
                CashboxOfflineMode = true,
                EndNonNullable = new NonNullableApiModel()
                {
                    Sell = shift.SellSaldoEnd,
                    Buy = shift.BuySaldoEnd,
                    ReturnBuy = shift.RetunBuySaldoEnd,
                    ReturnSell = shift.RetunSellSaldoEnd
                },
                StartNonNullable = new NonNullableApiModel()
                {
                    Sell = shift.SellSaldoBegin,
                    Buy = shift.BuySaldoBegin,
                    ReturnBuy = shift.RetunBuySaldoBegin,
                    ReturnSell = shift.RetunSellSaldoBegin
                },
                SumInCashbox = shift.KkmBalance,
                PutMoneySum = 0,
                TakeMoneySum = 0
            };
        }
        private OperationTypeSummaryApiModel GetOperation(List<ShiftOperation> shiftOperations, OperationTypeEnum type)
        {
            return new OperationTypeSummaryApiModel
            {
                Change = 0,
                Taken = shiftOperations.Where(o => o.OperationType == type)
                    .Sum(o => o.TotalAmount),
                VAT = 0,
                TotalCount = shiftOperations.Where(o => o.OperationType == type)
                    .Sum(o => o.Count),
                PaymentsByTypesApiModel = new List<PaymentsByTypesApiModel>(),
                Discount = 0,
                Markup = 0,
                Count = 0
            };
        }
    }
}