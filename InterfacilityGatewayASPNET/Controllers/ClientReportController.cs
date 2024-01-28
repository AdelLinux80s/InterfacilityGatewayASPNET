using InterfacilityGatewayASPNET.dto;
using InterfacilityGatewayASPNET.Models;
using InterfacilityGatewayASPNET.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace InterfacilityGatewayASPNET.Controllers
{
    public class ClientReportController : Controller
    {


        private MyDatebase _context;

        public ClientReportController()
        {
            _context = new MyDatebase();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: model
        public ActionResult Index()
        {
            List<ClientReport> ClientReports = _context.ClientReports.ToList();
            List<IndexViewDto> IndexViewDto = new List<IndexViewDto>();

            foreach (ClientReport clientReport in ClientReports)
            {
                IndexViewDto tempIndexViewDto = new IndexViewDto();
                tempIndexViewDto.ClientReportIndexViewDto = clientReport;


                tempIndexViewDto.IdIndexViewDto = clientReport.Id.ToString();
                Category Category = _context.Categories.Find(clientReport.CategoryId);

                tempIndexViewDto.CategoryIndexViewDto = Category.Name;


                EligibilityStatus EligibilityStatus = _context.EligibilityStatus.Find(clientReport.EligibilityStatusId);
                tempIndexViewDto.EligibilityStatusIndexViewDto = EligibilityStatus.Name;

                tempIndexViewDto.RequestDateIndexViewDto = clientReport.RequestDate.ToString();

                IndexViewDto.Add(tempIndexViewDto);


            }
            return View(IndexViewDto);
        }

        public ActionResult New()
        {
            return View();
        }


        public ActionResult Create()
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
            return View(ClientReportViewModel);
        }

        [HttpPost]
        public ActionResult Save(ClientReportViewModel model)
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




            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {
            var clientReport = _context.ClientReports.SingleOrDefault(c => c.Id == id);
            var IndexViewDto = new IndexViewDto();






            if (clientReport == null)
                return HttpNotFound();

            IndexViewDto.ClientReportIndexViewDto = clientReport;
            IndexViewDto.EligibilityStatusIndexViewDto = _context.EligibilityStatus.Find(clientReport.EligibilityStatusId).Name;
            IndexViewDto.CategoryIndexViewDto = _context.Categories.Find(clientReport.CategoryId).Name;
            IndexViewDto.RequestStatusIndexViewDto = _context.RequestStatuses.Find(clientReport.RequestStatusId).Status;

            return View(IndexViewDto);

        }

        public ActionResult Edit(int id)
        {
            var clientRequest = _context.ClientReports.SingleOrDefault(model => model.Id == id);
            if (clientRequest == null)
            {
                return HttpNotFound();
            }

            var DOB = clientRequest.DateOfBirth.Date.ToString("yyyy-MM-dd");
            //clientRequest.DateOfBirth = clientRequest.DateOfBirth.ToString(format: "yyyy-MM-dd");
            var categories = _context.Categories.ToList();
            var eligibilityStatus = _context.EligibilityStatus.ToList();
            var requestStatus = _context.RequestStatuses.ToList();
            var ClientReportViewModel = new ClientReportViewModel
            {
                ClientReport = clientRequest,
                Categories = categories,
                EligibilityStatuses = eligibilityStatus,
                RequestStatuses = requestStatus

            };

            return View("Create", ClientReportViewModel);
        }

    }
}