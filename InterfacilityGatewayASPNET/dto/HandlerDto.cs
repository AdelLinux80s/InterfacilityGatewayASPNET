using InterfacilityGatewayASPNET.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InterfacilityGatewayASPNET.dto
{
    public class HandlerDto
    {
        public HandlerTransferRequest HandlerTransferRequestHandlerDto { get; set; }
        public ClientReport ClientReportHandlerDto { get; set; }

        public HandlerActionDisposition HandlerActionDispositionHandlerDto { get; set; }

        public int NextUser { get; set; }

        public int SupervisorId { get; set; }

        public int UserInChargeId { get; set; }

        public int LayoutUserGroupId { get; set; }

        //public byte NextUserInchargeGroupId { get; set; }
        public string IdHandlerDto { get; set; }

        [Display(Name = "Eligibility Status")]
        public string EligibilityStatusHandlerDto { get; set; }


        [Display(Name = "Urgency")]
        public string CategoryHandlerDto { get; set; }

        public string RequestDateHandlerDto { get; set; }

        [Display(Name = "Request Status")]
        public string RequestStatusHandlerDto { get; set; }

        public int StatisticsPatientAdmittedByMRP { get; set; }
        public int StatostocsPatientOnTheWayByMRP { get; set; }

        //public int StatisticsPendingRequestsByUser { get; set; }

        //public int LayoutUser { get; set; }

        public IEnumerable<DropDownUserDto> DropDownUserDto { get; set; }

        public IEnumerable<DropDownActionDispositionDto> DropDownActionDispositionDtos { get; set; }

        public UpladedPDF pdfFile { get; set; }
    }
}