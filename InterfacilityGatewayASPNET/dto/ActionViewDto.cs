using InterfacilityGatewayASPNET.Models;
using System.Collections.Generic;

namespace InterfacilityGatewayASPNET.dto
{
    public class ActionViewDto
    {
        public ClientReport ClientReportActionViewDto { get; set; }

        public HandlerTransferRequest HandlerTransferRequest { get; set; }

        public string IdActionViewDto { get; set; }

        public string EligibilityStatusActionViewDto { get; set; }

        public string CategoryActionViewDto { get; set; }

        public string RequestDateActionViewDto { get; set; }

        public string RequestStatusActionViewDto { get; set; }

        public int NextIncharge { get; set; }

        public IEnumerable<ReceivingStationUser> ReceivingStationUsers { get; set; }
    }
}