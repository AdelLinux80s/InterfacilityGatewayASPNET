namespace InterfacilityGatewayASPNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRestOfModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocialNumber = c.Int(nullable: false),
                        Nationality = c.String(),
                        City = c.String(),
                        ReferringFacility = c.String(),
                        FullName = c.String(),
                        Gender = c.String(),
                        Email = c.String(),
                        Phone1 = c.String(),
                        Phone2 = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        MedicalRecordNumber = c.Int(nullable: false),
                        EligibilityStatusId = c.Byte(nullable: false),
                        RequestDate = c.DateTime(),
                        CategoryId = c.Byte(nullable: false),
                        RequestStatusId = c.Byte(nullable: false),
                        HandlerTransferRequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dispositions",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Divisions",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                        DepartmentId = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EligibilityStatus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HandlerActionDispositions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HandlerTransferRequestId = c.Int(nullable: false),
                        UserInChargeId = c.Int(nullable: false),
                        DispositionId = c.Byte(nullable: false),
                        Comment = c.String(),
                        RequestDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HandlerTransferRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientReportId = c.Int(nullable: false),
                        UserInChargeId = c.Int(nullable: false),
                        UserInchargeGroupId = c.Byte(nullable: false),
                        RequestDate = c.DateTime(),
                        IsOpened = c.Boolean(nullable: false),
                        IsAdmitted = c.Boolean(nullable: false),
                        UpladedPDFId = c.Int(nullable: false),
                        AdmittingMRP = c.Int(nullable: false),
                        IsOnTheWay = c.Boolean(nullable: false),
                        AdmissionDate = c.DateTime(),
                        DepartmentId = c.Short(nullable: false),
                        ToFinalize = c.Boolean(nullable: false),
                        AssignedBed = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicalDirectorUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Alias = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DepartmentId = c.Short(nullable: false),
                        GroupId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicalDoctorUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Alias = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DepartmentId = c.Short(nullable: false),
                        GroupId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReceivingStationUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Alias = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DepartmentId = c.Short(nullable: false),
                        GroupId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequestStatus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UpladedPDFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FileContent = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ValidatorUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Alias = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DepartmentId = c.Short(nullable: false),
                        GroupId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientReports", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ClientReports", new[] { "CategoryId" });
            DropTable("dbo.ValidatorUsers");
            DropTable("dbo.UpladedPDFs");
            DropTable("dbo.RequestStatus");
            DropTable("dbo.ReceivingStationUsers");
            DropTable("dbo.MedicalDoctorUsers");
            DropTable("dbo.MedicalDirectorUsers");
            DropTable("dbo.HandlerTransferRequests");
            DropTable("dbo.HandlerActionDispositions");
            DropTable("dbo.EligibilityStatus");
            DropTable("dbo.Divisions");
            DropTable("dbo.Dispositions");
            DropTable("dbo.Departments");
            DropTable("dbo.ClientReports");
            DropTable("dbo.Categories");
        }
    }
}
