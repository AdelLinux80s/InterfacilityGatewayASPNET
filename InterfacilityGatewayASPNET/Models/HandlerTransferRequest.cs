using System;

namespace InterfacilityGatewayASPNET.Models
{
    public class HandlerTransferRequest
    {
        public int Id { get; set; }
        public int ClientReportId { get; set; }
        public int UserInChargeId { get; set; }

        public byte UserInchargeGroupId { get; set; }
        public DateTime? RequestDate { get; set; }

        public bool IsOpened { get; set; }

        public bool IsAdmitted { get; set; }
        public int UpladedPDFId { get; set; }

        public int AdmittingMRP { get; set; }

        public bool IsOnTheWay { get; set; }

        public DateTime? AdmissionDate { get; set; }

        public short DepartmentId { get; set; }

        public bool ToFinalize { get; set; }

        public string AssignedBed { get; set; }
    }
}