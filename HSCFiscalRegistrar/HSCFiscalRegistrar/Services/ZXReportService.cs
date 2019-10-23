using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Models.Enums;

namespace HSCFiscalRegistrar.Services
{
    public class ZxReportService
    {
        public static void AddShiftProps(Shift shift, IQueryable<Operation> operations)
        {
            shift.BuySaldoEnd = shift.BuySaldoBegin +
                                operations.Where(o => o.Type == OperationTypeEnum.OPERATION_BUY).Sum(o => o.Amount);
            shift.SellSaldoEnd = shift.SellSaldoBegin +
                                 operations.Where(o => o.Type == OperationTypeEnum.OPERATION_SELL)
                                     .Sum(o => o.Amount);
            shift.RetunSellSaldoEnd = shift.RetunSellSaldoBegin + operations
                                          .Where(o => o.Type == OperationTypeEnum.OPERATION_SELL_RETURN)
                                          .Sum(o => o.Amount);
            shift.RetunBuySaldoEnd = shift.RetunBuySaldoBegin +
                                     operations.Where(o => o.Type == OperationTypeEnum.OPERATION_BUY)
                                         .Sum(o => o.Amount);
            CalculateBalance(shift, operations);
        }

        public static List<ShiftOperation> GetShiftOperations(IQueryable<Operation> operations, Shift shift)
        {
            var shiftOperations = new List<ShiftOperation>
            {
                GetShiftOperation(operations, shift, OperationTypeEnum.OPERATION_BUY),
                GetShiftOperation(operations, shift, OperationTypeEnum.OPERATION_SELL),
                GetShiftOperation(operations, shift, OperationTypeEnum.OPERATION_BUY_RETURN),
                GetShiftOperation(operations, shift, OperationTypeEnum.OPERATION_SELL_RETURN)
            };
            return shiftOperations;
        }

        public static void CloseShift(bool isClose, Shift shift)
        {
            if (isClose)
            {
                shift.CloseDate = DateTime.Now;
            }
        }

        private static ShiftOperation GetShiftOperation(IQueryable<Operation> operations, Shift shift,
            OperationTypeEnum type)
        {
            return new ShiftOperation
            {
                OperationType = type,
                CardAmount = operations
                    .Where(o => o.Type == type)
                    .Sum(o => o.CardAmount),
                CashAmount = operations
                    .Where(o => o.Type == type)
                    .Sum(o => o.CashAmount),
                Count = operations.Count(o => o.Type == type),
                ShiftId = shift.Id,
                TotalAmount = operations
                    .Where(o => o.Type == type)
                    .Sum(o => o.Amount),
                Change = operations.Where(o => o.Type == type).Sum(o => o.ChangeAmount)
            };
        }

        private static void CalculateBalance(Shift shift, IQueryable<Operation> operations)
        {
            shift.KkmBalance = operations
                                   .Where(o => o.Type == OperationTypeEnum.OPERATION_SELL)
                                   .Sum(o => o.Amount) +
                               operations
                                   .Where(o => o.Type == OperationTypeEnum.OPERATION_BUY_RETURN)
                                   .Sum(o => o.Amount) +
                               shift.SellSaldoBegin +
                               shift.RetunBuySaldoBegin -
                               operations.Where(o => o.Type == OperationTypeEnum.OPERATION_BUY)
                                   .Sum(o => o.Amount) -
                               operations.Where(o => o.Type == OperationTypeEnum.OPERATION_SELL_RETURN)
                                   .Sum(o => o.Amount) - shift.RetunBuySaldoBegin - shift.RetunSellSaldoBegin;
        }
    }
}