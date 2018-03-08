namespace HRIS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeFirstName = c.String(),
                        EmployeLastName = c.String(),
                        EmployeNameWithInitials = c.String(),
                        EmployeeAddress = c.String(),
                        PhoneNumber = c.String(),
                        Nic = c.String(),
                        Status = c.Boolean(nullable: false),
                        Email = c.String(),
                        DOJ = c.DateTime(nullable: false),
                        DateConfirmed = c.DateTime(nullable: false),
                        EmploymentType = c.String(),
                        DOB = c.DateTime(nullable: false),
                        MaritalStatus = c.String(),
                        Gender = c.String(),
                        TransportationMode = c.String(),
                        Distance = c.Int(nullable: false),
                        TravelTime = c.DateTime(nullable: false),
                        DistancePollingStation = c.Int(nullable: false),
                        PollingStationName = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.DesignationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employee", new[] { "DesignationId" });
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            DropTable("dbo.Employee");
        }
    }
}
