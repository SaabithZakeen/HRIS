namespace HRIS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttendanceModified1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Attendance", newName: "EmployeeAttendance");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.EmployeeAttendance", newName: "Attendance");
        }
    }
}
