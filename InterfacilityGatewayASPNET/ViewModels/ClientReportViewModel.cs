using InterfacilityGatewayASPNET.dto;
using InterfacilityGatewayASPNET.Models;
using System.Collections.Generic;

namespace InterfacilityGatewayASPNET.ViewModels
{
    public class ClientReportViewModel
    {
        public ClientReport ClientReport { get; set; }
        //public Category Category { get; set; }
        public IEnumerable<RequestStatus> RequestStatuses { get; set; }

        // public List<SelectListItem> DepartmentsSelectListItems { get; set; }

        // public SelectList DeparrtmentDropDown { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<EligibilityStatus> EligibilityStatuses { get; set; }

        public FileDto FileDto { get; set; }
    }
}