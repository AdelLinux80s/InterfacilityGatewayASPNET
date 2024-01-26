using System;

namespace InterfacilityGatewayASPNET.Models
{
    public class HandlerActionDisposition
    {
        public int Id { get; set; }
        public int HandlerTransferRequestId { get; set; }
        public int UserInChargeId { get; set; }
        public byte DispositionId { get; set; }
        public string Comment { get; set; }

        public DateTime? RequestDate { get; set; }
    }
}