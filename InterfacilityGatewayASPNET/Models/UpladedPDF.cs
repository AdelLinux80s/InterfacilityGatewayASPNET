namespace InterfacilityGatewayASPNET.Models
{
    public class UpladedPDF
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
    }
}