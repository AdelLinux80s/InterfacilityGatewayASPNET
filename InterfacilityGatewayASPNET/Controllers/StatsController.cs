using InterfacilityGatewayASPNET.dto;
using InterfacilityGatewayASPNET.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace InterfacilityGatewayASPNET.Controllers
{
    public class StatsController : Controller
    {




        private MyDatebase _context;

        public StatsController()
        {
            _context = new MyDatebase();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Stats
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult PopulateStatsByUser(int Id)
        {

            //IEnumerable<HandlerTransferRequest> HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == Id).ToList();

            List<HandlerTransferRequest> HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == Id).ToList();


            List<HandlerDto> HandlerDtos = new List<HandlerDto>();


            foreach (HandlerTransferRequest HandlerTransferRequest in HandlerTransferRequests)
            {

                HandlerDto tempHandlerDto = new HandlerDto();

                ClientReport ClientReport = _context.ClientReports.Find(HandlerTransferRequest.ClientReportId);
                tempHandlerDto.ClientReportHandlerDto = ClientReport;
                tempHandlerDto.HandlerTransferRequestHandlerDto = HandlerTransferRequest;
                tempHandlerDto.IdHandlerDto = HandlerTransferRequest.Id.ToString();







                Category Category = _context.Categories.Find(ClientReport.CategoryId);

                tempHandlerDto.CategoryHandlerDto = Category.Name;


                EligibilityStatus EligibilityStatus = _context.EligibilityStatus.Find(ClientReport.EligibilityStatusId);
                tempHandlerDto.EligibilityStatusHandlerDto = EligibilityStatus.Name;

                tempHandlerDto.RequestDateHandlerDto = ClientReport.RequestDate.ToString();
                tempHandlerDto.UserInChargeId = Id;
                HandlerDtos.Add(tempHandlerDto);


            }


            ViewData["UserInCharge"] = "https://localhost:44360/HandlerTransferRequest/Index/" + Id;

            return View(HandlerDtos);







            //return View(HandlerTransferRequests);
        }

    }
}