namespace InterfacilityGatewayASPNET.Models
{
    public class ChairmanUser
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public short DepartmentId { get; set; }
        public byte GroupId { get; set; }
    }
}