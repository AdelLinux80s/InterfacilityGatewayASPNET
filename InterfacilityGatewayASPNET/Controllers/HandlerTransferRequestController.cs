using InterfacilityGatewayASPNET.dto;
using InterfacilityGatewayASPNET.Models;
using InterfacilityGatewayASPNET.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace InterfacilityGatewayASPNET.Controllers
{
    public class HandlerTransferRequestController : Controller
    {

        private MyDatebase _context;

        public HandlerTransferRequestController()
        {
            _context = new MyDatebase();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: HandlerTransferRequest
        public ActionResult Index(int id, int groupId)
        {


            List<HandlerTransferRequest> HandlerTransferRequests = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> OnTheWayCases = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> AdmittedLast14Days = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> HandlerTransferRequestToFinialiseVsDepartmental = new List<HandlerTransferRequest>();
            DateTime date14DaysAgo = DateTime.Now.AddDays(-14);

            bool UserValid = false;
            //string UserName = null;
            string UserName = GetUserFirstName(id, groupId);
            int departmentId = GetUserDepartment(id, groupId);

            switch (groupId)
            {
                case 1:
                    //counting  Total Pending Request
                    //HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened && model.ToFinalize == false).ToList();
                    HandlerTransferRequests = GetHandlerTransferPendingRequestsForValidatorUser(id);

                    // counting on the way cases
                    //OnTheWayCases = _context.handlerTransferRequests.Where(model =>  model.IsOnTheWay).ToList();
                    OnTheWayCases = GetOnTheWayCasesAll(id);

                    // counting total admissions in the last 14 days
                    //AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();

                    AdmittedLast14Days = GetAdmissionsLast14DaysAll(id);

                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeList(id);

                    //UserName = _context.ValidatorUsers.Find(id).FirstName;
                    //UserName = GetUserFirstName(id, groupId);
                    UserValid = true;

                    break;
                case 2:
                    //counting  Total Pending Request
                    //HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened).ToList();
                    HandlerTransferRequests = GetHandlerTransferPendingRequestsForAllExceptValidator(id);


                    //int  RSUser = _context.ReceivingStationUsers.Find(id).DepartmentId;
                    // counting on the way cases
                    //OnTheWayCases = _context.handlerTransferRequests.Where(model => model.DepartmentId == RSUser && model.IsOnTheWay).ToList();
                    OnTheWayCases = GetOnTheWayCasesByDepartment(id, groupId);


                    // counting total admissions in the last 14 days
                    ////AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.DepartmentId == RSUser && model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();
                    AdmittedLast14Days = GetAdmissionsLast14DaysByDepartment(id, groupId);

                    //get FinalizeListByDepartment
                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeListByDepartment(departmentId);


                    break;
                case 3:
                    //counting  Total Pending Request
                    //HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened).ToList();
                    HandlerTransferRequests = GetHandlerTransferPendingRequestsForAllExceptValidator(id);



                    //OnTheWayCases = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == id && model.IsOnTheWay).ToList();
                    OnTheWayCases = GetOnTheWayCasesByMRP(id);
                    // counting total admissions in the last 14 days
                    //AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == id && model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();
                    AdmittedLast14Days = GetAdmissionsLast14DaysByMRP(id);

                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeListByDepartment(departmentId);

                    break;
                case 4:
                    //counting  Total Pending Request
                    //HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened).ToList();
                    HandlerTransferRequests = GetHandlerTransferPendingRequestsForAllExceptValidator(id);

                    //int ChairmanUser = _context.ChairmanUsers.Find(id).DepartmentId;

                    // counting on the way cases
                    //OnTheWayCases = _context.handlerTransferRequests.Where(model => model.DepartmentId == ChairmanUser && model.IsOnTheWay).ToList();
                    OnTheWayCases = GetOnTheWayCasesByDepartment(id, groupId);


                    // counting total admissions in the last 14 days
                    //AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.DepartmentId == ChairmanUser && model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();
                    AdmittedLast14Days = GetAdmissionsLast14DaysByDepartment(id, groupId);

                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeListByDepartment(departmentId);

                    break;
                case 5:
                    //counting  Total Pending Request
                    //HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened).ToList();
                    HandlerTransferRequests = GetHandlerTransferPendingRequestsForAllExceptValidator(id);

                    // counting on the way cases
                    //OnTheWayCases = _context.handlerTransferRequests.Where(model => model.IsOnTheWay).ToList();
                    OnTheWayCases = GetOnTheWayCasesAll(id);
                    // counting total admissions in the last 14 days
                    //AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();
                    AdmittedLast14Days = GetAdmissionsLast14DaysAll(id);

                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeList(id);


                    break;
                default: throw new System.ArgumentException("Some error message", nameof(HandlerTransferRequest.UserInchargeGroupId));
            };



            int TotalAdmittedLast14Days = AdmittedLast14Days.Count;
            int TotalOnTheWayCases = OnTheWayCases.Count;
            int TotalPendingRequest = HandlerTransferRequests.Count;
            int TotalToFinalizeVsDepartmentalRequest = HandlerTransferRequestToFinialiseVsDepartmental.Count;

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
                tempHandlerDto.UserInChargeId = id;
                HandlerDtos.Add(tempHandlerDto);


            }


            ViewData["UserName"] = UserName;
            ViewData["TotalAdmittedLast14Days"] = TotalAdmittedLast14Days;
            ViewData["TotalOnTheWayCases"] = TotalOnTheWayCases;
            ViewData["TotalPendingRequest"] = TotalPendingRequest;
            ViewData["TotalToFinalizeVsDepartmentalRequest"] = TotalToFinalizeVsDepartmentalRequest;


            ViewData["validator"] = UserValid;

            ViewData["UserInCharge"] = "https://localhost:44360/HandlerTransferRequest/Index/" + id + "/" + groupId;
            ViewData["IsAdmittedByMRP"] = "https://localhost:44360/HandlerTransferRequest/IsAdmitted/" + id + "/" + groupId;
            ViewData["IsOnTheWay"] = "https://localhost:44360/HandlerTransferRequest/IsOnTheWay/" + id + "/" + groupId;
            ViewData["FinalizeList"] = "https://localhost:44360/HandlerTransferRequest/FinalizeList/" + id + "/" + groupId;
            ViewData["Create"] = "https://localhost:44360/HandlerTransferRequest/Create/" + id;


            return View(HandlerDtos);

        }


        public ActionResult Create(int id)
        {
            var categories = _context.Categories.ToList();
            var eligibilityStatus = _context.EligibilityStatus.ToList();
            var requestStatus = _context.RequestStatuses.ToList();
            var ClientReportViewModel = new ClientReportViewModel
            {
                Categories = categories,
                EligibilityStatuses = eligibilityStatus,
                RequestStatuses = requestStatus


            };

            // List<SelectListItem> DepartmentsSelectListItems = new List<SelectListItem>();


            //TempData["pdf"];
            //ClientReportViewModel.FileDto = TempData["pdf"];




            // ViewBag.ListItem = DepartmentsSelectListItems;

            //ClientReportViewModel.DeparrtmentDropDown = new SelectList(DepartmentsSelectListItems);

            List<HandlerTransferRequest> HandlerTransferRequests = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> OnTheWayCases = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> AdmittedLast14Days = new List<HandlerTransferRequest>();
            //List<HandlerTransferRequest> HandlerTransferRequestToFinialise = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> HandlerTransferRequestToFinialiseVsDepartmental = new List<HandlerTransferRequest>();



            DateTime date14DaysAgo = DateTime.Now.AddDays(-14);

            ValidatorUser validatorUser = GetValidatorUser(id);

            HandlerTransferRequests = GetHandlerTransferPendingRequestsForValidatorUser(validatorUser.Id);
            // counting on the way cases
            //OnTheWayCases = _context.handlerTransferRequests.Where(model => model.IsOnTheWay == true).ToList();
            OnTheWayCases = GetOnTheWayCasesAll(validatorUser.Id);
            // counting total admissions in the last 14 days
            //AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.IsAdmitted == true && model.AdmissionDate > date14DaysAgo).ToList();
            AdmittedLast14Days = GetAdmissionsLast14DaysAll(validatorUser.Id);

            //get finalize list
            //HandlerTransferRequestToFinialise = GetFinalizeList(validatorUser.Id);
            HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeList(validatorUser.Id);

            bool UserValid = true;

            int TotalAdmittedLast14Days = AdmittedLast14Days.Count;
            int TotalOnTheWayCases = OnTheWayCases.Count;
            int TotalPendingRequest = HandlerTransferRequests.Count;
            //int TotalToFinalizeRequest = HandlerTransferRequestToFinialise.Count;
            int TotalToFinalizeVsDepartmentalRequest = HandlerTransferRequestToFinialiseVsDepartmental.Count;







            ViewData["TotalAdmittedLast14Days"] = TotalAdmittedLast14Days;
            ViewData["TotalOnTheWayCases"] = TotalOnTheWayCases;
            ViewData["TotalPendingRequest"] = TotalPendingRequest;
            //ViewData["TotalToFinalizeVsDepartmentalRequest"] = TotalToFinalizeRequest;
            ViewData["TotalToFinalizeVsDepartmentalRequest"] = TotalToFinalizeVsDepartmentalRequest;


            ViewData["validator"] = UserValid;


            ViewData["UserInCharge"] = "https://localhost:44360/HandlerTransferRequest/Index/" + validatorUser.Id + "/" + validatorUser.GroupId;


            ViewData["IsAdmittedByMRP"] = "https://localhost:44360/HandlerTransferRequest/IsAdmitted/" + validatorUser.Id + "/" + validatorUser.GroupId;
            ViewData["IsOnTheWay"] = "https://localhost:44360/HandlerTransferRequest/IsOnTheWay/" + validatorUser.Id + "/" + validatorUser.GroupId;
            ViewData["FinalizeList"] = "https://localhost:44360/HandlerTransferRequest/FinalizeList/" + validatorUser.Id + "/" + validatorUser.GroupId;
            ViewData["Create"] = "https://localhost:44360/HandlerTransferRequest/Create/" + validatorUser.Id;

            return View(ClientReportViewModel);
        }


        public ActionResult FinalizeList(int id, int groupId)
        {


            List<HandlerTransferRequest> HandlerTransferRequests = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> OnTheWayCases = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> AdmittedLast14Days = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> HandlerTransferRequestsTotalPending = new List<HandlerTransferRequest>();

            //DateTime date14DaysAgo = DateTime.Now.AddDays(-14);





            //counting  Total Pending Request
            //HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened && model.ToFinalize == true).ToList();
            HandlerTransferRequestsTotalPending = GetHandlerTransferPendingRequestsForValidatorUser(id);
            HandlerTransferRequests = GetFinalizeList(id);


            // counting on the way cases
            //OnTheWayCases = _context.handlerTransferRequests.Where(model => model.IsOnTheWay).ToList();
            OnTheWayCases = GetOnTheWayCasesAll(id);
            // counting total admissions in the last 14 days
            //AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();
            AdmittedLast14Days = GetAdmissionsLast14DaysAll(id);

            bool UserValid = true;





            int TotalAdmittedLast14Days = AdmittedLast14Days.Count;
            int TotalOnTheWayCases = OnTheWayCases.Count;
            int TotalPendingRequest = HandlerTransferRequestsTotalPending.Count;
            int TotalToFinalizeRequest = HandlerTransferRequests.Count;

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
                tempHandlerDto.UserInChargeId = id;
                HandlerDtos.Add(tempHandlerDto);


            }



            ViewData["TotalAdmittedLast14Days"] = TotalAdmittedLast14Days;
            ViewData["TotalOnTheWayCases"] = TotalOnTheWayCases;
            ViewData["TotalPendingRequest"] = TotalPendingRequest;
            ViewData["TotalToFinalizeVsDepartmentalRequest"] = TotalToFinalizeRequest;


            ViewData["validator"] = UserValid;

            ViewData["UserInCharge"] = "https://localhost:44360/HandlerTransferRequest/Index/" + id + "/" + groupId;
            ViewData["IsAdmittedByMRP"] = "https://localhost:44360/HandlerTransferRequest/IsAdmitted/" + id + "/" + groupId;
            ViewData["IsOnTheWay"] = "https://localhost:44360/HandlerTransferRequest/IsOnTheWay/" + id + "/" + groupId;
            ViewData["FinalizeList"] = "https://localhost:44360/HandlerTransferRequest/FinalizeList/" + id + "/" + groupId;
            ViewData["Create"] = "https://localhost:44360/HandlerTransferRequest/Create/" + id;

            return View(HandlerDtos);

        }


        public ActionResult DispositionEdit(int id)
        {
            HandlerTransferRequest HandlerTransferRequest = _context.handlerTransferRequests.Find(id);
            ClientReport ClientReport = _context.ClientReports.Find(HandlerTransferRequest.ClientReportId);
            HandlerActionDisposition handlerActionDisposition = new HandlerActionDisposition();
            //UserDto nextUser = new UserDto();
            UpladedPDF upladedPDF = getFileContent(HandlerTransferRequest.UpladedPDFId);



            bool UserValid = false;




            var HandlerDto = new HandlerDto()
            {
                HandlerTransferRequestHandlerDto = HandlerTransferRequest,
                ClientReportHandlerDto = ClientReport,
                HandlerActionDispositionHandlerDto = handlerActionDisposition,
                pdfFile = upladedPDF





            };

            switch (HandlerTransferRequest.UserInchargeGroupId)
            {
                case 1:
                    HandlerDto.DropDownUserDto = GetRecevingStationUsers();
                    break;
                case 2:
                    int ReceivingStationDepartmentId = _context.ReceivingStationUsers.Find(HandlerTransferRequest.UserInChargeId).DepartmentId;
                    HandlerDto.DropDownUserDto = GetMedicalDoctorUsers(ReceivingStationDepartmentId);
                    break;
                case 3: //HandlerDto.DropDownUserDto = GetChairmanUser();
                    int MedicalDoctorDepartmentId = _context.MedicalDoctorUsers.Find(HandlerTransferRequest.UserInChargeId).DepartmentId;

                    //_context.ChairmanUsers.Where(model => model.DepartmentId == MedicalDoctorDepartmentId);
                    int ChairmanId = _context.ChairmanUsers.First(model => model.DepartmentId == MedicalDoctorDepartmentId).Id;
                    HandlerDto.NextUser = ChairmanId;
                    HandlerDto.DropDownActionDispositionDtos = GetDropDownActionDisposition();
                    break;
                case 4: //HandlerDto.DropDownUserDto = GetMedicalDirectorUsers();

                    int MDId = _context.MedicalDirectorUsers.FirstOrDefault().Id;
                    HandlerDto.NextUser = MDId;

                    HandlerDto.DropDownActionDispositionDtos = GetDropDownActionDisposition();
                    break;
                case 5: //HandlerDto.DropDownUserDto = GetValidatorUsers();
                    int Validator = _context.ValidatorUsers.FirstOrDefault().Id;
                    HandlerDto.NextUser = Validator;
                    HandlerDto.DropDownActionDispositionDtos = GetDropDownActionDisposition();
                    break;
                default: throw new System.ArgumentException("Some error message", nameof(HandlerTransferRequest.UserInchargeGroupId));
            };





            //ValidatorUser validatorUser = _context.ValidatorUsers.Find(HandlerTransferRequest.UserInChargeId);
            //if (validatorUser != null)
            //{
            //    IEnumerable<ReceivingStationUser> receivingStationUsers = _context.ReceivingStationUsers.ToList();
            //    HandlerDto.DropDownUserDto = receivingStationUsers;
            //}

            //ReceivingStationUser receivingStationUser = _context.ReceivingStationUsers.Find(id);
            //if (receivingStationUser != null)
            //{
            //    IEnumerable<ReceivingStationUser> xreceivingStationUser = _context.ReceivingStationUsers.ToList();
            //}


            //MedicalDirectorUser medicalDirectorUser = _context.MedicalDirectorUsers.Find(id);
            //if (medicalDirectorUser != null)
            //{
            //    IEnumerable<MedicalDirectorUser> medicalDirectorUsers = _context.MedicalDirectorUsers.ToList();
            //}




            if (HandlerTransferRequest == null)
            {
                return HttpNotFound();
            }



            HandlerDto.EligibilityStatusHandlerDto = _context.EligibilityStatus.Find(ClientReport.EligibilityStatusId).Name;
            HandlerDto.CategoryHandlerDto = _context.Categories.Find(ClientReport.CategoryId).Name;
            HandlerDto.RequestStatusHandlerDto = _context.RequestStatuses.Find(ClientReport.RequestStatusId).Status;
            //HandlerDto.UserInChargeId = HandlerTransferRequest.UserInChargeId;

            //ViewData["UserInChageLayout"] = HandlerTransferRequest.UserInChargeId;


            List<HandlerTransferRequest> HandlerTransferRequests = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> OnTheWayCases = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> AdmittedLast14Days = new List<HandlerTransferRequest>();
            //List<HandlerTransferRequest> TotalAdmissions = new List<HandlerTransferRequest>();
            //List<HandlerTransferRequest> HandlerTransferRequestToFinialise = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> HandlerTransferRequestToFinialiseVsDepartmental = new List<HandlerTransferRequest>();
            DateTime date14DaysAgo = DateTime.Now.AddDays(-14);


            int departmentId = GetUserDepartment(HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId, HandlerDto.HandlerTransferRequestHandlerDto.UserInchargeGroupId);

            switch (HandlerDto.HandlerTransferRequestHandlerDto.UserInchargeGroupId)
            {
                case 1:
                    //counting  Total Pending Request
                    //HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId && model.IsOpened == true).ToList();
                    HandlerTransferRequests = GetHandlerTransferPendingRequestsForValidatorUser(HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId);


                    // counting on the way cases
                    OnTheWayCases = _context.handlerTransferRequests.Where(model => model.IsOnTheWay == true).ToList();

                    // counting total admissions in the last 14 days
                    AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.IsAdmitted == true && model.AdmissionDate > date14DaysAgo).ToList();


                    //get tofinalise list
                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeList(HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId);

                    UserValid = true;


                    //listing total admissins
                    //TotalAdmissions = _context.handlerTransferRequests.Where(model => model.IsAdmitted == true).ToList();
                    break;
                case 2:
                    //counting  Total Pending Request
                    HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened == true).ToList();
                    // counting on the way cases

                    //int departmentId = _context.ReceivingStationUsers.Find(id).DepartmentId;
                    //int departmentId = _context.ReceivingStationUsers.Find(HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId).DepartmentId;


                    OnTheWayCases = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId && model.IsOnTheWay == true).ToList();

                    // counting total admissions in the last 14 days
                    AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId && model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();

                    // counting total admissions
                    //TotalAdmissions = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId && model.IsAdmitted).ToList();

                    //get FinalizeListByDepartment
                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeListByDepartment(departmentId);


                    break;
                case 3:
                    //counting  Total Pending Request
                    HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened).ToList();
                    // counting on the way cases
                    OnTheWayCases = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == id && model.IsOnTheWay).ToList();

                    // counting total admissions in the last 14 days
                    AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == id && model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();

                    // counting total admissions
                    //TotalAdmissions = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == id && model.IsAdmitted).ToList();

                    //get FinalizeListByDepartment
                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeListByDepartment(departmentId);

                    break;
                case 4:

                    //int departmentId2 = _context.ChairmanUsers.Find(id).DepartmentId;
                    int departmentId2 = _context.ChairmanUsers.Find(HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId).DepartmentId;


                    //counting  Total Pending Request
                    HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened).ToList();
                    // counting on the way cases
                    OnTheWayCases = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId2 && model.IsOnTheWay).ToList();

                    // counting total admissions in the last 14 days
                    AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId2 && model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();


                    // counting total admissions
                    //TotalAdmissions = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId2 && model.IsAdmitted).ToList();

                    //get FinalizeListByDepartment
                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeListByDepartment(departmentId);

                    break;
                case 5:
                    //counting  Total Pending Request
                    HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened == true).ToList();
                    // counting on the way cases
                    OnTheWayCases = _context.handlerTransferRequests.Where(model => model.IsOnTheWay == true).ToList();

                    // counting total admissions in the last 14 days
                    AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.IsAdmitted == true && model.AdmissionDate > date14DaysAgo).ToList();

                    // counting total admissions
                    //TotalAdmissions = _context.handlerTransferRequests.Where(model => model.IsAdmitted == true).ToList();

                    //get tofinalise list
                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeList(HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId);

                    break;
                default: throw new System.ArgumentException("Some error message", nameof(HandlerTransferRequest.UserInchargeGroupId));
            };



            int TotalAdmittedLast14Days = AdmittedLast14Days.Count;
            int TotalOnTheWayCases = OnTheWayCases.Count;
            int TotalPendingRequest = HandlerTransferRequests.Count;
            //int TotalToFinalizeRequest = HandlerTransferRequestToFinialise.Count;
            int TotalToFinalizeVsDepartmentalRequest = HandlerTransferRequestToFinialiseVsDepartmental.Count;






            ViewData["TotalAdmittedLast14Days"] = TotalAdmittedLast14Days;
            ViewData["TotalOnTheWayCases"] = TotalOnTheWayCases;
            ViewData["TotalPendingRequest"] = TotalPendingRequest;
            ViewData["TotalToFinalizeVsDepartmentalRequest"] = TotalToFinalizeVsDepartmentalRequest;

            ViewData["validator"] = UserValid;


            ViewData["UserInCharge"] = "https://localhost:44360/HandlerTransferRequest/Index/" + HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId + "/" + HandlerDto.HandlerTransferRequestHandlerDto.UserInchargeGroupId;


            ViewData["IsAdmittedByMRP"] = "https://localhost:44360/HandlerTransferRequest/IsAdmitted/" + HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId + "/" + HandlerDto.HandlerTransferRequestHandlerDto.UserInchargeGroupId;
            ViewData["IsOnTheWay"] = "https://localhost:44360/HandlerTransferRequest/IsOnTheWay/" + HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId + "/" + HandlerDto.HandlerTransferRequestHandlerDto.UserInchargeGroupId;
            ViewData["FinalizeList"] = "https://localhost:44360/HandlerTransferRequest/FinalizeList/" + HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId + "/" + HandlerDto.HandlerTransferRequestHandlerDto.UserInchargeGroupId; ;
            ViewData["Create"] = "https://localhost:44360/HandlerTransferRequest/Create/" + HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId;


            return View(HandlerDto);

        }

        public ActionResult FinalizeEdit(int id)
        {
            HandlerTransferRequest HandlerTransferRequest = _context.handlerTransferRequests.Find(id);
            ClientReport ClientReport = _context.ClientReports.Find(HandlerTransferRequest.ClientReportId);
            //HandlerActionDisposition handlerActionDisposition = new HandlerActionDisposition();
            //UserDto nextUser = new UserDto();

            if (HandlerTransferRequest == null)
            {
                return HttpNotFound();
            }

            bool UserValid = false;

            var HandlerDto = new HandlerDto()
            {
                HandlerTransferRequestHandlerDto = HandlerTransferRequest,
                ClientReportHandlerDto = ClientReport
                //HandlerActionDispositionHandlerDto = handlerActionDisposition




            };


            bool BookBed = false;

            if (HandlerDto.HandlerTransferRequestHandlerDto.IsOnTheWay == true)
            {
                BookBed = true;
            }


            HandlerDto.EligibilityStatusHandlerDto = _context.EligibilityStatus.Find(ClientReport.EligibilityStatusId).Name;
            HandlerDto.CategoryHandlerDto = _context.Categories.Find(ClientReport.CategoryId).Name;
            HandlerDto.RequestStatusHandlerDto = _context.RequestStatuses.Find(ClientReport.RequestStatusId).Status;



            List<HandlerTransferRequest> HandlerTransferRequests = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> OnTheWayCases = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> AdmittedLast14Days = new List<HandlerTransferRequest>();
            //List<HandlerTransferRequest> TotalAdmissions = new List<HandlerTransferRequest>();
            //List<HandlerTransferRequest> HandlerTransferRequestToFinialise = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> HandlerTransferRequestToFinialiseVsDepartmental = new List<HandlerTransferRequest>();

            DateTime date14DaysAgo = DateTime.Now.AddDays(-14);



            //HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId && model.IsOpened == true).ToList();
            HandlerTransferRequests = GetHandlerTransferPendingRequestsForValidatorUser(HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId);


            // counting on the way cases
            OnTheWayCases = _context.handlerTransferRequests.Where(model => model.IsOnTheWay == true).ToList();

            // counting total admissions in the last 14 days
            AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.IsAdmitted == true && model.AdmissionDate > date14DaysAgo).ToList();

            //get fininalize list
            HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeList(HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId);

            UserValid = true;


            int TotalAdmittedLast14Days = AdmittedLast14Days.Count;
            int TotalOnTheWayCases = OnTheWayCases.Count;
            int TotalPendingRequest = HandlerTransferRequests.Count;
            //int TotalToFinalizeRequest = HandlerTransferRequestToFinialise.Count;
            int TotalToFinalizeVsDepartmentalRequest = HandlerTransferRequestToFinialiseVsDepartmental.Count;







            ViewData["TotalAdmittedLast14Days"] = TotalAdmittedLast14Days;
            ViewData["TotalOnTheWayCases"] = TotalOnTheWayCases;
            ViewData["TotalPendingRequest"] = TotalPendingRequest;
            ViewData["TotalToFinalizeVsDepartmentalRequest"] = TotalToFinalizeVsDepartmentalRequest;


            ViewData["BookBed"] = BookBed;
            ViewData["validator"] = UserValid;


            ViewData["UserInCharge"] = "https://localhost:44360/HandlerTransferRequest/Index/" + HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId + "/" + HandlerDto.HandlerTransferRequestHandlerDto.UserInchargeGroupId;


            ViewData["IsAdmittedByMRP"] = "https://localhost:44360/HandlerTransferRequest/IsAdmitted/" + HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId + "/" + HandlerDto.HandlerTransferRequestHandlerDto.UserInchargeGroupId;
            ViewData["IsOnTheWay"] = "https://localhost:44360/HandlerTransferRequest/IsOnTheWay/" + HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId + "/" + HandlerDto.HandlerTransferRequestHandlerDto.UserInchargeGroupId;
            ViewData["FinalizeList"] = "https://localhost:44360/HandlerTransferRequest/FinalizeList/" + HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId + "/" + HandlerDto.HandlerTransferRequestHandlerDto.UserInchargeGroupId;
            ViewData["Create"] = "https://localhost:44360/HandlerTransferRequest/Create/" + HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId;


            return View(HandlerDto);


        }

        [HttpPost]
        public ActionResult Save(HandlerDto HandlerDto)
        {
            if (HandlerDto == null)
            {
                return HttpNotFound();
            }



            var HandlerTR = _context.handlerTransferRequests.Find(HandlerDto.HandlerTransferRequestHandlerDto.Id);
            var HandlerAD = new HandlerActionDisposition
            {
                RequestDate = DateTime.Now,
                HandlerTransferRequestId = HandlerDto.HandlerTransferRequestHandlerDto.Id,
                UserInChargeId = HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId,
                Comment = HandlerDto.HandlerActionDispositionHandlerDto.Comment,
                DispositionId = HandlerDto.HandlerActionDispositionHandlerDto.DispositionId
            };

            _context.HandlerActionDisposition.Add(HandlerAD);
            _context.SaveChanges();


            HandlerTR.UserInChargeId = HandlerDto.NextUser;
            int NextGroupId = HandlerDto.HandlerTransferRequestHandlerDto.UserInchargeGroupId;

            if (NextGroupId == 3 && HandlerAD.DispositionId == 1)
            {
                HandlerTR.AdmittingMRP = HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId;
                HandlerTR.DepartmentId = _context.MedicalDoctorUsers.Find(HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId).DepartmentId;
            }

            if ((NextGroupId == 4 || NextGroupId == 5) && HandlerAD.DispositionId != 1)
            {
                HandlerTR.AdmittingMRP = 0;

            }

            if ((NextGroupId == 5) && HandlerAD.DispositionId == 1)
            {

                HandlerTR.IsOnTheWay = true;

            }

            if (NextGroupId == 5)
            {

                HandlerTR.ToFinalize = true;

            }

            int tempUserInchargeGroupId = ((1 + NextGroupId) % 6);
            if (tempUserInchargeGroupId == 0)
            {
                tempUserInchargeGroupId = 1;
            }
            HandlerTR.UserInchargeGroupId = (byte)tempUserInchargeGroupId;
            _context.SaveChanges();

            int TempId = HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId;


            return RedirectToRoute(new { controller = "HandlerTransferRequest", action = "Index", id = TempId, groupId = HandlerDto.HandlerTransferRequestHandlerDto.UserInchargeGroupId });

            //return View("Index/{id}");
        }


        public ActionResult SaveCreate(ClientReportViewModel model)
        {

            if (model.ClientReport.Id == 0)
            {
                ClientReport tempClientReport = model.ClientReport;
                tempClientReport.RequestDate = DateTime.Now;
                //model.ClientReport.RequestDate = DateTime.Now;
                //model.HandlerTransferRequestId = _context.ValidatorUsers.FirstOrDefault().Id;

                ValidatorUser validatorUser = _context.ValidatorUsers.FirstOrDefault();

                UpladedPDF file = new UpladedPDF();

                //if (new byte[model.FileDto.FileDtoHttpPostedFileBaseFile.InputStream.Length] != null)
                //{
                //UpladedPDF file = new UpladedPDF();
                //byte[] TempUploadFile = new byte[model.FileDto.FileDtoHttpPostedFileBaseFile.InputStream.Length];
                byte[] TempUploadFile = new byte[model.FileDto.FileDtoHttpPostedFileBaseFile.InputStream.Length];
                model.FileDto.FileDtoHttpPostedFileBaseFile.InputStream.Read(TempUploadFile, 0, TempUploadFile.Length);

                //file.FileName = model.FileDto.FileDtoFileName;
                file.FileName = "clientreport" + model.ClientReport.Id + DateTime.Now.ToString("yymmssfff");

                //file.FileName = "report2";
                file.FileContent = TempUploadFile;
                _context.UpladedPDFFiles.Add(file);
                _context.SaveChanges();
                var pdfFileId = file.Id;



                //}






                HandlerTransferRequest handlerTransferRequest = new HandlerTransferRequest()
                {

                    UserInChargeId = validatorUser.Id,
                    UserInchargeGroupId = validatorUser.GroupId,
                    RequestDate = model.ClientReport.RequestDate,
                    IsOpened = true,
                    UpladedPDFId = pdfFileId

                };

                // UpladedPDF file = new UpladedPDF();
                // //byte[] TempUploadFile = new byte[model.FileDto.FileDtoHttpPostedFileBaseFile.InputStream.Length];
                // // here is the  excpetion located
                // byte[] uploadFile = new byte[model.FileDto.FileDtoHttpPostedFileBaseFile.InputStream.Length];
                // model.FileDto.FileDtoHttpPostedFileBaseFile.InputStream.Read(uploadFile, 0, uploadFile.Length);

                // file.FileName = model.FileDto.FileDtoFileName;
                // //file.FileName = "report2";
                // file.FileContent = uploadFile;




                ClientReport tempCclientReport = model.ClientReport;


                //_context.ClientReports.Add(tempCclientReport);
                //_context.SaveChanges();

                //file.FileName = "clientreport" + tempCclientReport.Id + DateTime.Now.ToString("yymmssfff");
                //_context.UpladedPDFFiles.Add(file);
                //_context.SaveChanges();

                //handlerTransferRequest.ClientReportId = model.ClientReport.Id;
                //handlerTransferRequest.UpladedPDFId = pdfFileId;

                //_context.handlerTransferRequests.Add(handlerTransferRequest);
                //_context.SaveChanges();
                _context.handlerTransferRequests.Add(handlerTransferRequest);

                _context.ClientReports.Add(tempCclientReport);
                _context.SaveChanges();

                handlerTransferRequest.ClientReportId = tempCclientReport.Id;
                tempCclientReport.HandlerTransferRequestId = handlerTransferRequest.Id;
                //_context.handlerTransferRequests.Add(handlerTransferRequest);
                _context.SaveChanges();


            }
            else
            {
                ClientReport dbClientReport = _context.ClientReports.Single(m => m.Id == model.ClientReport.Id);
                dbClientReport.SocialNumber = model.ClientReport.SocialNumber;
                dbClientReport.Nationality = model.ClientReport.Nationality;
                dbClientReport.City = model.ClientReport.City;
                dbClientReport.ReferringFacility = model.ClientReport.ReferringFacility;
                dbClientReport.FullName = model.ClientReport.FullName;
                dbClientReport.Gender = model.ClientReport.Gender;
                dbClientReport.Email = model.ClientReport.Email;
                dbClientReport.Phone1 = model.ClientReport.Phone1;
                dbClientReport.Phone2 = model.ClientReport.Phone2;
                dbClientReport.DateOfBirth = model.ClientReport.DateOfBirth;
                dbClientReport.MedicalRecordNumber = model.ClientReport.MedicalRecordNumber;
                dbClientReport.EligibilityStatusId = model.ClientReport.EligibilityStatusId;
                dbClientReport.RequestDate = model.ClientReport.RequestDate;
                dbClientReport.CategoryId = model.ClientReport.CategoryId;
                dbClientReport.RequestStatusId = model.ClientReport.RequestStatusId;
                dbClientReport.HandlerTransferRequestId = model.ClientReport.HandlerTransferRequestId;

                //file upload





            }

            _context.SaveChanges();



            return RedirectToRoute(new { controller = "HandlerTransferRequest", action = "Index", id = 5000, groupId = 1 });
            //return RedirectToAction("Index");

        }



        [HttpPost]
        public ActionResult FinalizeSave(HandlerDto HandlerDto)
        {
            if (HandlerDto == null)
            {
                return HttpNotFound();
            }

            int TempId = HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId;


            var HandlerTR = _context.handlerTransferRequests.Find(HandlerDto.HandlerTransferRequestHandlerDto.Id);

            string tempComment = null;
            if (HandlerDto.HandlerActionDispositionHandlerDto.Comment != null)
            {
                tempComment = "Assigned Bed: " + HandlerDto.HandlerActionDispositionHandlerDto.Comment;
            }

            var HandlerAD = new HandlerActionDisposition
            {
                RequestDate = DateTime.Now,
                HandlerTransferRequestId = HandlerDto.HandlerTransferRequestHandlerDto.Id,
                UserInChargeId = HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId,
                Comment = tempComment,
                DispositionId = 1,


            };

            _context.HandlerActionDisposition.Add(HandlerAD);
            _context.SaveChanges();

            if (HandlerDto.HandlerActionDispositionHandlerDto.Comment != null)
            {
                HandlerTR.IsAdmitted = true;
                HandlerTR.AdmissionDate = DateTime.Now;
                HandlerTR.AssignedBed = HandlerDto.HandlerActionDispositionHandlerDto.Comment;

            }

            else
            {
                HandlerTR.IsAdmitted = false;
                HandlerTR.AdmissionDate = null;
                HandlerTR.AssignedBed = null;
            }


            HandlerTR.IsOpened = false;

            HandlerTR.IsOnTheWay = false;

            HandlerTR.ToFinalize = false;
            //HandlerTR.AssignedBed = "Bed: " + 

            //_context.handlerTransferRequests.Add(HandlerTR);
            _context.SaveChanges();

            ;

            return RedirectToRoute(new { controller = "HandlerTransferRequest", action = "Index", id = TempId, groupId = HandlerDto.HandlerTransferRequestHandlerDto.UserInchargeGroupId });
        }


        public ActionResult Detail(int id, int LayoutUser, int groupId)
        {
            HandlerTransferRequest HandlerTransferRequest = _context.handlerTransferRequests.Find(id);
            ClientReport ClientReport = _context.ClientReports.Find(HandlerTransferRequest.ClientReportId);
            HandlerActionDisposition handlerActionDisposition = new HandlerActionDisposition();


            //UserDto nextUser = new UserDto();

            bool UserValid = false;


            var HandlerDto = new HandlerDto()
            {
                HandlerTransferRequestHandlerDto = HandlerTransferRequest,
                ClientReportHandlerDto = ClientReport,
                HandlerActionDispositionHandlerDto = handlerActionDisposition




            };



            if (HandlerTransferRequest == null)
            {
                return HttpNotFound();
            }



            HandlerDto.EligibilityStatusHandlerDto = _context.EligibilityStatus.Find(ClientReport.EligibilityStatusId).Name;
            HandlerDto.CategoryHandlerDto = _context.Categories.Find(ClientReport.CategoryId).Name;
            HandlerDto.RequestStatusHandlerDto = _context.RequestStatuses.Find(ClientReport.RequestStatusId).Status;
            HandlerDto.UserInChargeId = LayoutUser;






            ////counting total pending cases
            //List<HandlerTransferRequest> TotalPendingRequest = _context.handlerTransferRequests.Where(model => model.UserInChargeId == LayoutUser && model.IsOpened).ToList();


            //// counting on the way cases
            //List<HandlerTransferRequest> OnTheWayCases = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == LayoutUser && model.IsOnTheWay).ToList();

            //// counting total admissions in the last 14 days
            //DateTime date14DaysAgo = DateTime.Now.AddDays(-14);


            //List<HandlerTransferRequest> AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == LayoutUser && model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();


            //int TotalAdmittedLast14Days = AdmittedLast14Days.Count;
            //int TotalOnTheWayCases = OnTheWayCases.Count;
            //int intTotalPendingRequest = TotalPendingRequest.Count;

            ////ViewData["TotalAdmittedLast14Days"] = TotalAdmittedLast14Days;
            ////ViewData["TotalOnTheWayCases"] = TotalOnTheWayCases;
            ////ViewData["TotalPendingRequest"] = intTotalPendingRequest;



            // new here


            List<HandlerTransferRequest> HandlerTransferRequests = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> OnTheWayCases = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> AdmittedLast14Days = new List<HandlerTransferRequest>();
            //List<HandlerTransferRequest> TotalAdmissions = new List<HandlerTransferRequest>();
            //List<HandlerTransferRequest> HandlerTransferRequestToFinialise = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> HandlerTransferRequestToFinialiseVsDepartmental = new List<HandlerTransferRequest>();

            DateTime date14DaysAgo = DateTime.Now.AddDays(-14);


            int tempId = LayoutUser;
            int tempGroupId = groupId;

            int departmentId = GetUserDepartment(LayoutUser, groupId);

            //switch (HandlerDto.HandlerTransferRequestHandlerDto.UserInchargeGroupId)
            switch (groupId)
            {
                case 1:
                    //counting  Total Pending Request
                    //HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == HandlerDto.HandlerTransferRequestHandlerDto.UserInChargeId && model.IsOpened == true).ToList();
                    HandlerTransferRequests = GetHandlerTransferPendingRequestsForValidatorUser(tempId);
                    // counting on the way cases
                    //OnTheWayCases = _context.handlerTransferRequests.Where(model => model.IsOnTheWay == true).ToList();
                    OnTheWayCases = GetOnTheWayCasesAll(tempId);
                    // counting total admissions in the last 14 days
                    //AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.IsAdmitted == true && model.AdmissionDate > date14DaysAgo).ToList();
                    AdmittedLast14Days = GetAdmissionsLast14DaysAll(tempId);


                    //get finalize list
                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeList(tempId);


                    UserValid = true;


                    //listing total admissins
                    //TotalAdmissions = _context.handlerTransferRequests.Where(model => model.IsAdmitted == true).ToList();
                    break;
                case 2:
                    //counting  Total Pending Request
                    //HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened == true).ToList();
                    HandlerTransferRequests = GetHandlerTransferPendingRequestsForAllExceptValidator(tempId);

                    // counting on the way cases

                    //int departmentId = _context.ReceivingStationUsers.Find(id).DepartmentId;

                    //OnTheWayCases = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId && model.IsOnTheWay == true).ToList();
                    OnTheWayCases = GetOnTheWayCasesByDepartment(tempId, tempGroupId);
                    // counting total admissions in the last 14 days
                    //AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId && model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();
                    AdmittedLast14Days = GetAdmissionsLast14DaysByDepartment(tempId, tempGroupId);
                    // counting total admissions
                    //TotalAdmissions = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId && model.IsAdmitted).ToList();

                    //get FinalizeListByDepartment
                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeListByDepartment(departmentId);


                    break;
                case 3:
                    //counting  Total Pending Request
                    HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened).ToList();
                    // counting on the way cases
                    OnTheWayCases = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == id && model.IsOnTheWay).ToList();

                    // counting total admissions in the last 14 days
                    AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == id && model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();

                    // counting total admissions
                    //TotalAdmissions = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == id && model.IsAdmitted).ToList();


                    //get FinalizeListByDepartment
                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeListByDepartment(departmentId);


                    break;
                case 4:

                    //int departmentId2 = _context.ChairmanUsers.Find(id).DepartmentId;
                    int departmentId2 = departmentId;



                    //counting  Total Pending Request
                    HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened).ToList();
                    // counting on the way cases
                    OnTheWayCases = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId2 && model.IsOnTheWay).ToList();

                    // counting total admissions in the last 14 days
                    AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId2 && model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();


                    // counting total admissions
                    //TotalAdmissions = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId2 && model.IsAdmitted).ToList();


                    //get FinalizeListByDepartment
                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeListByDepartment(departmentId);


                    break;
                case 5:
                    //counting  Total Pending Request
                    HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened == true).ToList();
                    // counting on the way cases
                    OnTheWayCases = _context.handlerTransferRequests.Where(model => model.IsOnTheWay == true).ToList();

                    // counting total admissions in the last 14 days
                    AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.IsAdmitted == true && model.AdmissionDate > date14DaysAgo).ToList();

                    // counting total admissions
                    //TotalAdmissions = _context.handlerTransferRequests.Where(model => model.IsAdmitted == true).ToList();

                    //get finalize list
                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeList(tempId);

                    break;
                default: throw new System.ArgumentException("Some error message", nameof(HandlerTransferRequest.UserInchargeGroupId));
            };



            int TotalAdmittedLast14Days = AdmittedLast14Days.Count;
            int TotalOnTheWayCases = OnTheWayCases.Count;
            int TotalPendingRequest = HandlerTransferRequests.Count;
            //int TotalToFinalizeRequest = HandlerTransferRequestToFinialise.Count;
            int TotalToFinalizeVsDepartmentalRequest = HandlerTransferRequestToFinialiseVsDepartmental.Count;







            ViewData["TotalAdmittedLast14Days"] = TotalAdmittedLast14Days;
            ViewData["TotalOnTheWayCases"] = TotalOnTheWayCases;
            ViewData["TotalPendingRequest"] = TotalPendingRequest;
            ViewData["TotalToFinalizeVsDepartmentalRequest"] = TotalToFinalizeVsDepartmentalRequest;



            ViewData["validator"] = UserValid;


            ViewData["UserInCharge"] = "https://localhost:44360/HandlerTransferRequest/Index/" + LayoutUser + "/" + groupId;


            ViewData["IsAdmittedByMRP"] = "https://localhost:44360/HandlerTransferRequest/IsAdmitted/" + LayoutUser + "/" + groupId;
            ViewData["IsOnTheWay"] = "https://localhost:44360/HandlerTransferRequest/IsOnTheWay/" + LayoutUser + "/" + groupId;
            ViewData["FinalizeList"] = "https://localhost:44360/HandlerTransferRequest/FinalizeList/" + LayoutUser + "/" + groupId;

            return View(HandlerDto);
        }


        // To be utilitzed later
        public ActionResult IsAdmittedByMRP(int Id)
        {

            //IEnumerable<HandlerTransferRequest> HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == id).ToList();


            List<HandlerTransferRequest> HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == Id && model.IsAdmitted == true).ToList();


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


            //ViewData["UserInCharge"] = "https://localhost:44360/HandlerTransferRequest/Index/" + id;

            //counting total pending cases
            List<HandlerTransferRequest> TotalPendingRequest = _context.handlerTransferRequests.Where(model => model.UserInChargeId == Id && model.IsOpened).ToList();


            // counting on the way cases
            List<HandlerTransferRequest> OnTheWayCases = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == Id && model.IsOnTheWay).ToList();

            // counting total admissions in the last 14 days
            DateTime date14DaysAgo = DateTime.Now.AddDays(-14);


            List<HandlerTransferRequest> AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == Id && model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();


            int TotalAdmittedLast14Days = AdmittedLast14Days.Count;
            int TotalOnTheWayCases = OnTheWayCases.Count;
            int intTotalPendingRequest = TotalPendingRequest.Count;

            ViewData["TotalAdmittedLast14Days"] = TotalAdmittedLast14Days;
            ViewData["TotalOnTheWayCases"] = TotalOnTheWayCases;
            ViewData["TotalPendingRequest"] = intTotalPendingRequest;




            //ViewData["LayoutUser"] = id;
            ViewData["UserInCharge"] = "https://localhost:44360/HandlerTransferRequest/Index/" + Id;
            ViewData["IsAdmittedByMRP"] = "https://localhost:44360/HandlerTransferRequest/IsAdmittedByMRP/" + Id;
            ViewData["IsOnTheWay"] = "https://localhost:44360/HandlerTransferRequest/IsOnTheWay/" + Id;



            return View(HandlerDtos);







            //return View(HandlerTransferRequests);
        }

        public ActionResult IsAdmittedByDepartment(int Id)
        {
            List<HandlerTransferRequest> HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.DepartmentId == Id && model.IsAdmitted == true).ToList();


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


            //ViewData["UserInCharge"] = "https://localhost:44360/HandlerTransferRequest/Index/" + id;

            //counting total pending cases
            List<HandlerTransferRequest> TotalPendingRequest = _context.handlerTransferRequests.Where(model => model.UserInChargeId == Id && model.IsOpened).ToList();


            // counting on the way cases
            List<HandlerTransferRequest> OnTheWayCases = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == Id && model.IsOnTheWay).ToList();

            // counting total admissions in the last 14 days
            DateTime date14DaysAgo = DateTime.Now.AddDays(-14);


            List<HandlerTransferRequest> AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == Id && model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();


            int TotalAdmittedLast14Days = AdmittedLast14Days.Count;
            int TotalOnTheWayCases = OnTheWayCases.Count;
            int intTotalPendingRequest = TotalPendingRequest.Count;

            ViewData["TotalAdmittedLast14Days"] = TotalAdmittedLast14Days;
            ViewData["TotalOnTheWayCases"] = TotalOnTheWayCases;
            ViewData["TotalPendingRequest"] = intTotalPendingRequest;




            //ViewData["LayoutUser"] = id;
            ViewData["UserInCharge"] = "https://localhost:44360/HandlerTransferRequest/Index/" + Id;
            ViewData["IsAdmittedByMRP"] = "https://localhost:44360/HandlerTransferRequest/IsAdmittedByMRP/" + Id;
            ViewData["IsOnTheWay"] = "https://localhost:44360/HandlerTransferRequest/IsOnTheWay/" + Id;



            return View(HandlerDtos);


        }

        public ActionResult IsAdmitted(int id, int groupId)
        {
            List<HandlerTransferRequest> HandlerTransferRequests = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> OnTheWayCases = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> AdmittedLast14Days = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> TotalAdmissions = new List<HandlerTransferRequest>();
            //List<HandlerTransferRequest> HandlerTransferRequestToFinialise = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> HandlerTransferRequestToFinialiseVsDepartmental = new List<HandlerTransferRequest>();

            DateTime date14DaysAgo = DateTime.Now.AddDays(-14);

            bool UserValid = false;
            string UserName = null;

            int departmentId = GetUserDepartment(id, groupId);


            switch (groupId)
            {
                case 1:
                    //counting  Total Pending Request
                    //HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened == true).ToList();
                    HandlerTransferRequests = GetHandlerTransferPendingRequestsForValidatorUser(id);

                    // counting on the way cases
                    //OnTheWayCases = _context.handlerTransferRequests.Where(model => model.IsOnTheWay == true).ToList();
                    OnTheWayCases = GetOnTheWayCasesAll(id);


                    // counting total admissions in the last 14 days
                    //AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.IsAdmitted == true && model.AdmissionDate > date14DaysAgo).ToList();
                    AdmittedLast14Days = GetAdmissionsLast14DaysAll(id);


                    //listing total admissins
                    TotalAdmissions = _context.handlerTransferRequests.Where(model => model.IsAdmitted == true).ToList();


                    //finalise total list
                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeList(id);

                    //UserName = _context.ValidatorUsers.Find(id).FirstName;
                    UserName = GetUserFirstName(id, groupId);
                    UserValid = true;


                    break;
                case 2:
                    //counting  Total Pending Request
                    //HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened == true).ToList();
                    HandlerTransferRequests = GetHandlerTransferPendingRequestsForAllExceptValidator(id);

                    // counting on the way cases

                    //int departmentId = _context.ReceivingStationUsers.Find(id).DepartmentId;

                    //OnTheWayCases = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId && model.IsOnTheWay == true).ToList();
                    OnTheWayCases = GetOnTheWayCasesByDepartment(id, groupId);
                    // counting total admissions in the last 14 days
                    //AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId && model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();
                    AdmittedLast14Days = GetAdmissionsLast14DaysByDepartment(id, groupId);
                    // counting total admissions
                    TotalAdmissions = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId && model.IsAdmitted).ToList();


                    //get FinalizeListByDepartment
                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeListByDepartment(departmentId);

                    break;
                case 3:
                    //counting  Total Pending Request
                    //HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened).ToList();
                    HandlerTransferRequests = GetHandlerTransferPendingRequestsForAllExceptValidator(id);

                    // counting on the way cases
                    //OnTheWayCases = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == id && model.IsOnTheWay).ToList();
                    OnTheWayCases = GetOnTheWayCasesByMRP(id);
                    // counting total admissions in the last 14 days
                    //AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == id && model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();
                    AdmittedLast14Days = GetAdmissionsLast14DaysByMRP(id);
                    // counting total admissions
                    TotalAdmissions = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == id && model.IsAdmitted).ToList();


                    //get FinalizeListByDepartment
                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeListByDepartment(departmentId);

                    break;
                case 4:

                    int departmentId2 = _context.ChairmanUsers.Find(id).DepartmentId;



                    //counting  Total Pending Request
                    //HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened).ToList();
                    HandlerTransferRequests = GetHandlerTransferPendingRequestsForAllExceptValidator(id);

                    // counting on the way cases
                    //OnTheWayCases = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId2 && model.IsOnTheWay).ToList();
                    OnTheWayCases = GetOnTheWayCasesByDepartment(id, groupId);
                    // counting total admissions in the last 14 days
                    //AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId2 && model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();
                    AdmittedLast14Days = GetAdmissionsLast14DaysByDepartment(id, groupId);

                    // counting total admissions
                    TotalAdmissions = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId2 && model.IsAdmitted).ToList();

                    //get FinalizeListByDepartment
                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeListByDepartment(departmentId);


                    break;
                case 5:
                    //counting  Total Pending Request
                    //HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened == true).ToList();
                    HandlerTransferRequests = GetHandlerTransferPendingRequestsForAllExceptValidator(id);

                    // counting on the way cases
                    //OnTheWayCases = _context.handlerTransferRequests.Where(model => model.IsOnTheWay == true).ToList();
                    OnTheWayCases = GetOnTheWayCasesAll(id);
                    // counting total admissions in the last 14 days
                    //AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.IsAdmitted == true && model.AdmissionDate > date14DaysAgo).ToList();
                    AdmittedLast14Days = GetAdmissionsLast14DaysAll(id);
                    // counting total admissions
                    TotalAdmissions = _context.handlerTransferRequests.Where(model => model.IsAdmitted == true).ToList();

                    //finalise total list
                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeList(id);


                    break;
                default: throw new System.ArgumentException("Some error message", nameof(HandlerTransferRequest.UserInchargeGroupId));
            };



            int TotalAdmittedLast14Days = AdmittedLast14Days.Count;
            int TotalOnTheWayCases = OnTheWayCases.Count;
            int TotalPendingRequest = HandlerTransferRequests.Count;
            //int TotalToFinalizeRequest = HandlerTransferRequestToFinialise.Count;
            int TotalToFinalizeVsDepartmentalRequest = HandlerTransferRequestToFinialiseVsDepartmental.Count;

            List<HandlerDto> HandlerDtos = new List<HandlerDto>();


            foreach (HandlerTransferRequest HandlerTransferRequest in TotalAdmissions)
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
                tempHandlerDto.UserInChargeId = id;
                tempHandlerDto.LayoutUserGroupId = groupId;
                HandlerDtos.Add(tempHandlerDto);


            }



            ViewData["TotalAdmittedLast14Days"] = TotalAdmittedLast14Days;
            ViewData["TotalOnTheWayCases"] = TotalOnTheWayCases;
            ViewData["TotalPendingRequest"] = TotalPendingRequest;
            ViewData["TotalToFinalizeVsDepartmentalRequest"] = TotalToFinalizeVsDepartmentalRequest;


            ViewData["UserName"] = UserName;
            ViewData["validator"] = UserValid
            ;
            ViewData["UserInCharge"] = "https://localhost:44360/HandlerTransferRequest/Index/" + id + "/" + groupId;
            ViewData["IsAdmittedByMRP"] = "https://localhost:44360/HandlerTransferRequest/IsAdmitted/" + id + "/" + groupId;
            ViewData["IsOnTheWay"] = "https://localhost:44360/HandlerTransferRequest/IsOnTheWay/" + id + "/" + groupId;
            ViewData["FinalizeList"] = "https://localhost:44360/HandlerTransferRequest/FinalizeList/" + id + "/" + groupId;
            ViewData["Create"] = "https://localhost:44360/HandlerTransferRequest/Create/" + id;

            return View(HandlerDtos);
        }
        public ActionResult IsOnTheWay(int id, int groupId)
        {

            List<HandlerTransferRequest> HandlerTransferRequests = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> OnTheWayCases = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> AdmittedLast14Days = new List<HandlerTransferRequest>();
            //List<HandlerTransferRequest> TotalAdmissions = new List<HandlerTransferRequest>();
            //List<HandlerTransferRequest> HandlerTransferRequestToFinialise = new List<HandlerTransferRequest>();
            List<HandlerTransferRequest> HandlerTransferRequestToFinialiseVsDepartmental = new List<HandlerTransferRequest>();

            DateTime date14DaysAgo = DateTime.Now.AddDays(-14);

            bool UserValid = false;

            //List<HandlerTransferRequest> HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == id && model.IsOnTheWay == true).ToList();


            //List<HandlerTransferRequest> HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened).ToList();







            int departmentId = GetUserDepartment(id, groupId);


            switch (groupId)
            {
                case 1:
                    //counting  Total Pending Request
                    //HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened == true).ToList();
                    HandlerTransferRequests = GetHandlerTransferPendingRequestsForValidatorUser(id);

                    // counting on the way cases
                    //OnTheWayCases = _context.handlerTransferRequests.Where(model => model.IsOnTheWay == true).ToList();
                    OnTheWayCases = GetOnTheWayCasesAll(id);
                    // counting total admissions in the last 14 days
                    //AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.IsAdmitted == true && model.AdmissionDate > date14DaysAgo).ToList();
                    AdmittedLast14Days = GetAdmissionsLast14DaysAll(id);

                    //get finalise total list
                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeList(id);


                    UserValid = true;

                    //listing total admissins
                    //TotalAdmissions = _context.handlerTransferRequests.Where(model => model.IsAdmitted == true).ToList();
                    break;
                case 2:
                    //counting  Total Pending Request
                    //HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened == true).ToList();
                    HandlerTransferRequests = GetHandlerTransferPendingRequestsForAllExceptValidator(id);

                    // counting on the way cases

                    //int departmentId = _context.ReceivingStationUsers.Find(id).DepartmentId;

                    //OnTheWayCases = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId && model.IsOnTheWay == true).ToList();
                    OnTheWayCases = GetOnTheWayCasesByDepartment(id, groupId);
                    // counting total admissions in the last 14 days
                    //AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId && model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();
                    AdmittedLast14Days = GetAdmissionsLast14DaysByDepartment(id, groupId);
                    // counting total admissions
                    //TotalAdmissions = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId && model.IsAdmitted).ToList();

                    //get FinalizeListByDepartment
                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeListByDepartment(departmentId);


                    break;
                case 3:
                    //counting  Total Pending Request
                    //HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened).ToList();
                    HandlerTransferRequests = GetHandlerTransferPendingRequestsForAllExceptValidator(id);

                    // counting on the way cases
                    //OnTheWayCases = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == id && model.IsOnTheWay).ToList();
                    OnTheWayCases = GetOnTheWayCasesByMRP(id);
                    // counting total admissions in the last 14 days
                    //AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == id && model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();
                    AdmittedLast14Days = GetAdmissionsLast14DaysByMRP(id);
                    // counting total admissions
                    //TotalAdmissions = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == id && model.IsAdmitted).ToList();


                    //get FinalizeListByDepartment
                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeListByDepartment(departmentId);

                    break;
                case 4:

                    int departmentId2 = _context.ChairmanUsers.Find(id).DepartmentId;



                    //counting  Total Pending Request
                    //HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened).ToList();
                    HandlerTransferRequests = GetHandlerTransferPendingRequestsForAllExceptValidator(id);
                    // counting on the way cases
                    //OnTheWayCases = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId2 && model.IsOnTheWay).ToList();
                    OnTheWayCases = GetOnTheWayCasesByDepartment(id, groupId);
                    // counting total admissions in the last 14 days
                    //AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId2 && model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();
                    AdmittedLast14Days = GetAdmissionsLast14DaysByDepartment(id, groupId);

                    // counting total admissions
                    //TotalAdmissions = _context.handlerTransferRequests.Where(model => model.DepartmentId == departmentId2 && model.IsAdmitted).ToList();

                    //get FinalizeListByDepartment
                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeListByDepartment(departmentId);


                    break;
                case 5:
                    //counting  Total Pending Request
                    //HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened == true).ToList();
                    HandlerTransferRequests = GetHandlerTransferPendingRequestsForAllExceptValidator(id);

                    // counting on the way cases
                    //OnTheWayCases = _context.handlerTransferRequests.Where(model => model.IsOnTheWay == true).ToList();
                    OnTheWayCases = GetOnTheWayCasesAll(id);
                    // counting total admissions in the last 14 days
                    //AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.IsAdmitted == true && model.AdmissionDate > date14DaysAgo).ToList();
                    AdmittedLast14Days = GetAdmissionsLast14DaysAll(id);

                    // counting total admissions
                    //TotalAdmissions = _context.handlerTransferRequests.Where(model => model.IsAdmitted == true).ToList();

                    //get finalise total list
                    HandlerTransferRequestToFinialiseVsDepartmental = GetFinalizeList(id);



                    break;
                default: throw new System.ArgumentException("Some error message", nameof(HandlerTransferRequest.UserInchargeGroupId));
            };



            int TotalAdmittedLast14Days = AdmittedLast14Days.Count;
            int TotalOnTheWayCases = OnTheWayCases.Count;
            int TotalPendingRequest = HandlerTransferRequests.Count;
            //int TotalToFinalizeRequest = HandlerTransferRequestToFinialise.Count;
            int TotalToFinalizeVsDepartmentalRequest = HandlerTransferRequestToFinialiseVsDepartmental.Count;













            List<HandlerDto> HandlerDtos = new List<HandlerDto>();


            foreach (HandlerTransferRequest HandlerTransferRequest in OnTheWayCases)
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
                tempHandlerDto.UserInChargeId = id;
                tempHandlerDto.LayoutUserGroupId = groupId;
                HandlerDtos.Add(tempHandlerDto);


            }

            // counting on the way cases
            //List<HandlerTransferRequest> OnTheWayCases = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == id && model.IsOnTheWay).ToList();

            // counting total admissions in the last 14 days

            //DateTime date14DaysAgo = DateTime.Now.AddDays(-14);
            //List<HandlerTransferRequest> AdmittedLast14Days = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == id && model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();


            //int TotalAdmittedLast14Days = AdmittedLast14Days.Count;
            //int TotalOnTheWayCases = OnTheWayCases.Count;
            //int intTotalPendingRequest = TotalPendingRequest.Count;

            ViewData["TotalAdmittedLast14Days"] = TotalAdmittedLast14Days;
            ViewData["TotalOnTheWayCases"] = TotalOnTheWayCases;
            ViewData["TotalPendingRequest"] = TotalPendingRequest;
            ViewData["TotalToFinalizeVsDepartmentalRequest"] = TotalToFinalizeVsDepartmentalRequest;



            ViewData["validator"] = UserValid;


            ViewData["UserInCharge"] = "https://localhost:44360/HandlerTransferRequest/Index/" + id + "/" + groupId;
            ViewData["IsAdmittedByMRP"] = "https://localhost:44360/HandlerTransferRequest/IsAdmitted/" + id + "/" + groupId;
            ViewData["IsOnTheWay"] = "https://localhost:44360/HandlerTransferRequest/IsOnTheWay/" + id + "/" + groupId;
            ViewData["FinalizeList"] = "https://localhost:44360/HandlerTransferRequest/FinalizeList/" + id + "/" + groupId;
            ViewData["Create"] = "https://localhost:44360/HandlerTransferRequest/Create/" + id;

            return View(HandlerDtos);
        }



        public ActionResult PDFRetrival(int id)
        {
            byte[] fileBytes = getFileContent(id).FileContent;
            string fileName = getFileContent(id).FileName;

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName + ".pdf");
        }
        private List<DropDownActionDispositionDto> GetDropDownActionDisposition()
        {
            IEnumerable<Dispositions> dispositions = _context.Dispositions.ToList();
            List<DropDownActionDispositionDto> dropDownActionDispositionDtos = new List<DropDownActionDispositionDto>();

            foreach (var disposition in dispositions)
            {
                DropDownActionDispositionDto temDto = new DropDownActionDispositionDto();
                if ((disposition.Id == 1 || disposition.Id == 2) || disposition.Id == 3)
                {
                    temDto.Id = disposition.Id;
                    temDto.Name = disposition.Name;
                    dropDownActionDispositionDtos.Add(temDto);
                }



            }

            return dropDownActionDispositionDtos;
            //throw new NotImplementedException();
        }

        private List<DropDownUserDto> GetValidatorUsers()
        {
            IEnumerable<ValidatorUser> validatorUsers = _context.ValidatorUsers.ToList();
            List<DropDownUserDto> dropDownUserDto = new List<DropDownUserDto>();
            foreach (var item in validatorUsers)
            {
                DropDownUserDto tempDto = new DropDownUserDto();
                tempDto.Id = item.Id;
                tempDto.Name = item.Alias;

                dropDownUserDto.Add(tempDto);

            }

            return dropDownUserDto;

            //throw new NotImplementedException();
        }

        private List<DropDownUserDto> GetMedicalDirectorUsers()
        {
            IEnumerable<MedicalDirectorUser> medicalDirectorUser = _context.MedicalDirectorUsers.ToList();
            List<DropDownUserDto> dropDownUserDto = new List<DropDownUserDto>();
            foreach (var item in medicalDirectorUser)
            {
                DropDownUserDto tempDto = new DropDownUserDto();
                tempDto.Id = item.Id;
                tempDto.Name = item.Alias;

                dropDownUserDto.Add(tempDto);

            }

            return dropDownUserDto;


            //throw new NotImplementedException();
        }

        private List<DropDownUserDto> GetChairmanUser()
        {

            IEnumerable<ChairmanUser> chairmanUsers = _context.ChairmanUsers.ToList();
            List<DropDownUserDto> dropDownUserDto = new List<DropDownUserDto>();
            foreach (var item in chairmanUsers)
            {
                DropDownUserDto tempDto = new DropDownUserDto();
                tempDto.Id = item.Id;
                tempDto.Name = item.Alias;

                dropDownUserDto.Add(tempDto);

            }

            return dropDownUserDto;



            //throw new NotImplementedException();
        }

        private List<DropDownUserDto> GetMedicalDoctorUsers(int ReceivingStationDepartmentId)
        {
            //Where(model => model.UserInChargeId == id && model.IsOpened).ToList();
            IEnumerable<MedicalDoctorUser> medicalDoctorUsers = _context.MedicalDoctorUsers.Where(model => model.DepartmentId == ReceivingStationDepartmentId).ToList();
            List<DropDownUserDto> dropDownUserDto = new List<DropDownUserDto>();
            foreach (var item in medicalDoctorUsers)
            {
                DropDownUserDto tempDto = new DropDownUserDto();
                tempDto.Id = item.Id;
                tempDto.Name = item.Alias;

                dropDownUserDto.Add(tempDto);

            }

            return dropDownUserDto;
        }

        private List<DropDownUserDto> GetRecevingStationUsers()
        {
            IEnumerable<ReceivingStationUser> receivingStationUsers = _context.ReceivingStationUsers.ToList();
            List<DropDownUserDto> dropDownUserDto = new List<DropDownUserDto>();
            foreach (var item in receivingStationUsers)
            {
                DropDownUserDto tempDto = new DropDownUserDto();
                tempDto.Id = item.Id;
                tempDto.Name = item.Alias;

                dropDownUserDto.Add(tempDto);

            }

            return dropDownUserDto;
        }

        private List<HandlerTransferRequest> GetHandlerTransferPendingRequestsForValidatorUser(int id)
        {

            List<HandlerTransferRequest> HandlerTransferRequests = new List<HandlerTransferRequest>();


            try
            {
                HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened && model.ToFinalize == false).ToList();
            }
            catch (ArgumentNullException ex)
            {
                ex.Data.Add("ValidatorUserId: ", id);
                throw ex;
            }



            return HandlerTransferRequests;
        }

        private List<HandlerTransferRequest> GetHandlerTransferPendingRequestsForAllExceptValidator(int id)
        {
            List<HandlerTransferRequest> HandlerTransferRequests = new List<HandlerTransferRequest>();


            try
            {
                HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened).ToList();
            }
            catch (ArgumentNullException ex)
            {
                ex.Data.Add("GetHandlerTransferPendingRequestsForAllExceptValidatorUserId: ", id);
                throw ex;
            }



            return HandlerTransferRequests;
        }



        private List<HandlerTransferRequest> GetOnTheWayCasesAll(int id)
        {
            List<HandlerTransferRequest> HandlerTransferRequests = new List<HandlerTransferRequest>();


            try
            {
                HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.IsOnTheWay).ToList();

            }
            catch (ArgumentNullException ex)
            {
                ex.Data.Add("GetOnTheWayCasesAllUserId: ", id);
                throw ex;
            }



            return HandlerTransferRequests;
        }


        private List<HandlerTransferRequest> GetOnTheWayCasesByMRP(int id)
        {
            List<HandlerTransferRequest> HandlerTransferRequests = new List<HandlerTransferRequest>();


            try
            {
                HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == id && model.IsOnTheWay).ToList();

            }
            catch (ArgumentNullException ex)
            {
                ex.Data.Add("GetOnTheWayCasesByMRPId: ", id);
                throw ex;
            }



            return HandlerTransferRequests;
        }

        private List<HandlerTransferRequest> GetOnTheWayCasesByDepartment(int id, int groupId)
        {
            List<HandlerTransferRequest> HandlerTransferRequests = new List<HandlerTransferRequest>();


            try
            {
                if (groupId == 2)
                {
                    int RSUserDepartmentId = _context.ReceivingStationUsers.Find(id).DepartmentId;
                    HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.DepartmentId == RSUserDepartmentId && model.IsOnTheWay).ToList();
                }


                if (groupId == 4)
                {
                    int ChairmanUserDepartmentId = _context.ChairmanUsers.Find(id).DepartmentId;
                    HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.DepartmentId == ChairmanUserDepartmentId && model.IsOnTheWay).ToList();
                }

            }
            catch (ArgumentNullException ex)
            {
                ex.Data.Add("GetOnTheWayCasesByDepartmentUserId: ", id);
                throw ex;
            }



            return HandlerTransferRequests;
        }


        private List<HandlerTransferRequest> GetAdmissionsLast14DaysAll(int id)
        {
            List<HandlerTransferRequest> HandlerTransferRequests = new List<HandlerTransferRequest>();
            DateTime date14DaysAgo = DateTime.Now.AddDays(-14);

            try
            {
                HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();
            }
            catch (ArgumentNullException ex)
            {
                ex.Data.Add("GetAdmissionsLast14DaysUserId: ", id);
                throw ex;
            }



            return HandlerTransferRequests;
        }

        private List<HandlerTransferRequest> GetAdmissionsLast14DaysByMRP(int id)
        {
            List<HandlerTransferRequest> HandlerTransferRequests = new List<HandlerTransferRequest>();
            DateTime date14DaysAgo = DateTime.Now.AddDays(-14);

            try
            {
                HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.AdmittingMRP == id && model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();
            }
            catch (ArgumentNullException ex)
            {
                ex.Data.Add("GetAdmissionsLast14DaysMRPUserId: ", id);
                throw ex;
            }



            return HandlerTransferRequests;
        }

        private List<HandlerTransferRequest> GetAdmissionsLast14DaysByDepartment(int id, int groupId)
        {
            List<HandlerTransferRequest> HandlerTransferRequests = new List<HandlerTransferRequest>();
            DateTime date14DaysAgo = DateTime.Now.AddDays(-14);

            try
            {
                if (groupId == 2)
                {
                    int RSUserDepartmentId = _context.ReceivingStationUsers.Find(id).DepartmentId;
                    HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.DepartmentId == RSUserDepartmentId && model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();

                }


                if (groupId == 4)
                {
                    int ChairmanUserDepartmentId = _context.ChairmanUsers.Find(id).DepartmentId;
                    HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.DepartmentId == ChairmanUserDepartmentId && model.IsAdmitted && model.AdmissionDate > date14DaysAgo).ToList();
                }

            }
            catch (ArgumentNullException ex)
            {
                ex.Data.Add("GetOnTheWayCasesByDepartmentUserId: ", id);
                throw ex;
            }



            return HandlerTransferRequests;
        }

        public List<HandlerTransferRequest> GetFinalizeList(int id)
        {
            List<HandlerTransferRequest> HandlerTransferRequests = new List<HandlerTransferRequest>();



            try
            {
                //HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.UserInChargeId == id && model.IsOpened && model.ToFinalize == true).ToList();
                HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.IsOpened && model.ToFinalize == true).ToList();

            }
            catch (ArgumentNullException ex)
            {
                ex.Data.Add("ValidatorUserId: ", id);
                throw ex;
            }



            return HandlerTransferRequests;



        }

        public List<HandlerTransferRequest> GetFinalizeListByDepartment(int id)
        {
            List<HandlerTransferRequest> HandlerTransferRequests = new List<HandlerTransferRequest>();



            try
            {
                HandlerTransferRequests = _context.handlerTransferRequests.Where(model => model.DepartmentId == id && model.IsOpened == true && model.ToFinalize == true).ToList();
            }
            catch (ArgumentNullException ex)
            {
                ex.Data.Add("GetFinalizeListByDepartment Id: ", id);
                throw ex;
            }



            return HandlerTransferRequests;
        }

        private string GetUserFirstName(int id, int groupId)
        {
            string UserFirstName;
            try
            {
                switch (groupId)
                {
                    case 1:
                        UserFirstName = _context.ValidatorUsers.Find(id).FirstName;
                        break;
                    case 2:
                        UserFirstName = _context.ReceivingStationUsers.Find(id).FirstName;
                        break;
                    case 3:
                        UserFirstName = _context.MedicalDoctorUsers.Find(id).FirstName;
                        break;
                    case 4:
                        UserFirstName = _context.ChairmanUsers.Find(id).FirstName;
                        break;
                    case 5:
                        UserFirstName = _context.MedicalDirectorUsers.Find(id).FirstName;
                        break;
                    default: throw new System.ArgumentException("Some error message", nameof(HandlerTransferRequest.UserInchargeGroupId));
                }
            }

            catch (ArgumentNullException ex)
            {
                ex.Data.Add("GetUserFirstName: ", id);
                throw ex;
            }


            return UserFirstName;
        }


        public int GetUserDepartment(int id, int groupId)
        {
            int departmentId;
            try
            {
                switch (groupId)
                {
                    case 1:
                        departmentId = _context.ValidatorUsers.Find(id).DepartmentId;
                        break;
                    case 2:
                        departmentId = _context.ReceivingStationUsers.Find(id).DepartmentId;
                        break;
                    case 3:
                        departmentId = _context.MedicalDoctorUsers.Find(id).DepartmentId;
                        break;
                    case 4:
                        departmentId = _context.ChairmanUsers.Find(id).DepartmentId;
                        break;
                    case 5:
                        departmentId = _context.MedicalDirectorUsers.Find(id).DepartmentId;
                        break;
                    default: throw new System.ArgumentException("Some error message", nameof(HandlerTransferRequest.UserInchargeGroupId));
                }
            }

            catch (ArgumentNullException ex)
            {
                ex.Data.Add("GetUserFirstName: ", id);
                throw ex;
            }


            return departmentId;
        }
        private ValidatorUser GetValidatorUser(int id)
        {
            ValidatorUser validatorUser = new ValidatorUser();



            try
            {
                validatorUser = _context.ValidatorUsers.Find(id);
            }

            catch (ArgumentNullException ex)
            {
                ex.Data.Add("GetValidatorUser: ", id);
                throw ex;
            }


            return validatorUser;
        }

        private UpladedPDF getFileContent(int id)
        {
            UpladedPDF pdfFile;
            try
            {

                pdfFile = _context.UpladedPDFFiles.Find(id);


            }

            catch (ArgumentNullException ex)
            {
                ex.Data.Add("PDF file not found: ", id);
                throw ex;
            }


            return pdfFile;
        }


    }
}