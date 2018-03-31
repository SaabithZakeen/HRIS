namespace HRIS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LeaveTypeRemoveEmployeeId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeAttendance", "EmployeeId", "dbo.Employee");
            DropIndex("dbo.EmployeeAttendance", new[] { "EmployeeId" });
            DropColumn("dbo.LeaveType", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LeaveType", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.EmployeeAttendance", "EmployeeId");
            AddForeignKey("dbo.EmployeeAttendance", "EmployeeId", "dbo.Employee", "Id", cascadeDelete: true);
        }
    }
}
