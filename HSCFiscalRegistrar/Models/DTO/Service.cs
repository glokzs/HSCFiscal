namespace Models.DTO
{
    public class Service
    {
        public RegInfo RegInfo { get; set; }
        
        public Service(RegInfo regInfo)
        {
            RegInfo = regInfo;
        }

        public Service()
        {
        }
    }
}