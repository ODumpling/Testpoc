namespace API.Models
{
    public class CsNetworkAdapter
    {
        public string Description { get; set; }
        public string ConnectionID { get; set; }
        public bool? DHCPEnabled { get; set; }
        public string DHCPServer { get; set; }
        public int ConnectionStatus { get; set; }
        public string IPAddresses { get; set; }
    }
}