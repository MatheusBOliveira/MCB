namespace MCB.Core.Infra.CrossCutting.Patterns.CommunicationProtocol
{
    public class Header
    {
        public string Language { get; set; }
        public Auth Auth { get; set; }
        public DeviceInfo DeviceInfo { get; set; }

        public Header()
        {
            Auth = new Auth();
            DeviceInfo = new DeviceInfo();
        }
    }
}


