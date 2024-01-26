using System.Data.Entity;



namespace InterfacilityGatewayASPNET.Models
{
    public class MyDatebase : DbContext
    {
        public DbSet<ValidatorUser> ValidatorUsers { get; set; }

        public DbSet<ReceivingStationUser> ReceivingStationUsers { get; set; }
        public DbSet<MedicalDoctorUser> MedicalDoctorUsers { get; set; }
        public DbSet<ChairmanUser> ChairmanUsers { get; set; }
        public DbSet<HandlerTransferRequest> handlerTransferRequests { get; set; }
        public DbSet<Department> DepartmentUsers { get; set; }
        public DbSet<Division> Divisions { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<RequestStatus> RequestStatuses { get; set; }

        public DbSet<ClientReport> ClientReports { get; set; }

        public DbSet<EligibilityStatus> EligibilityStatus { get; set; }

        public DbSet<MedicalDirectorUser> MedicalDirectorUsers { get; set; }

        public DbSet<HandlerActionDisposition> HandlerActionDisposition { get; set; }
        public DbSet<Dispositions> Dispositions { get; set; }

        public DbSet<UpladedPDF> UpladedPDFFiles { get; set; }
    }
}