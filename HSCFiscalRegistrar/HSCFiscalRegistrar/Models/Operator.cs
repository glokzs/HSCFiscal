namespace HSCFiscalRegistrar.Models
{
    public class Operator
    {
        public string Id { get; set; }
        public virtual User User { get; set; }
        public string UserId { get; set; }
    }
}