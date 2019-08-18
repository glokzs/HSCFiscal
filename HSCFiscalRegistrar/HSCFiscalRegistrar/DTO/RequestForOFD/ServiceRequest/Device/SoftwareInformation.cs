namespace HSCFiscalRegistrar.DTO.RequestForOFD.ServiceRequest.Device
{
    public class SoftwareInformation
    {
        public ModuleInformation ModuleInfos { get; set; }
        public string HardwareArch { get; set; }
        public string OsFamily { get; set; }
        public string OsVersion { get; set; }
        public string OsExtendedInfo { get; set; }
        public string RuntimeVersion { get; set; }
        public string PartnerId { get; set; }
    }
}