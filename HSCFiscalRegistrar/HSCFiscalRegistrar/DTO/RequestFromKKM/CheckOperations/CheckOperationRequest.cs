namespace HSCFiscalRegistrar.DTO.RequestFromKKM.CheckOperations
{
    public class CheckOperationRequest : DataRequest
    {
        public Position PositionId { get; set; }
        public virtual Position Positions { get; set; }
        
        public string TicketModifiersTypeId { get; set; }
        public virtual TicketModifiersType TicketModifiers { get; set; }
        
        public long Payments { get; set; }
        public decimal Change { get; set; }
        public long Type { get; set; }
        public string CustomerEmail { get; set; }
        public int RoundType { get; set; }
    }
}