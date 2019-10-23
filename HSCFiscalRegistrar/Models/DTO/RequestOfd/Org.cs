using Models.Enums;

namespace Models.DTO.RequestOperatorOfd
{
    public class Org
    {
        public string Okved { get; set; }
        public TaxationTypeEnum TaxationType { get; set; }
        public string Inn { get; set; }
        public string Title { get; set; }
    }
}
