namespace InterfacilityGatewayASPNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingChairmanUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChairmanUsers",
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
            DropTable("dbo.ChairmanUsers");
        }
    }
}
