namespace HSCFiscalRegistrar.DTO.RequestForOFD
{
    public class ModuleInformation
    {
        public int Name { get; set; }
        public int Version { get; set; }
        public int BuildInfo { get; set; }
        public DeviceInformation DeviceInfo { get; set; }
        public Auxiliary Auxiliary { get; set; }
        public string BuildArch { get; set; }
                        
    }
}