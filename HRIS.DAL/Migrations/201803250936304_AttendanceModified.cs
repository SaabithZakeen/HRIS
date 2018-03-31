namespace HRIS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttendanceModified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendance", "EmployeeId", "dbo.Employee");
            DropIndex("dbo.Attendance", new[] { "EmployeeId" });
            CreateTable(
                "dbo.EmployeeLeaveManagement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupervisorId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        LeaveType = c.Int(nullable: false),
                        IsApproved = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LeaveEntitlement",
                c => new
                    {
                        LeaveId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        LeavesAvailable = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LeaveId);
            
            CreateTable(
                "dbo.LeaveType",
                c => new
                    {
                        LeaveId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        LeaveTypeName = c.String(),
                        LeaveDays = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LeaveId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LeaveType");
            DropTable("dbo.LeaveEntitlement");
            DropTable("dbo.EmployeeLeaveManagement");
            CreateIndex("dbo.Attendance", "EmployeeId");
            AddForeignKey("dbo.Attendance", "EmployeeId", "dbo.Employee", "Id", cascadeDelete: true);
        }
    }
}
