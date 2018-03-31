namespace HRIS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttendanceModified2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.EmployeeAttendance", "EmployeeId");
            //AddForeignKey("dbo.EmployeeAttendance", "EmployeeId", "dbo.Employee", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.EmployeeAttendance", "EmployeeId", "dbo.Employee");
            //DropIndex("dbo.EmployeeAttendance", new[] { "EmployeeId" });
        }
    }
}
