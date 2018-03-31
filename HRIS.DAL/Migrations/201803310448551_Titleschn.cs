namespace HRIS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Titleschn : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.EmployeeAttendance");
            AddColumn("dbo.Designations", "DesignationName", c => c.String());
            AlterColumn("dbo.EmployeeAttendance", "EmployeeId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.EmployeeAttendance", "EmployeeId");
            DropColumn("dbo.EmployeeAttendance", "Id");
            DropColumn("dbo.EmployeeAttendance", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeAttendance", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.EmployeeAttendance", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.EmployeeAttendance");
            AlterColumn("dbo.EmployeeAttendance", "EmployeeId", c => c.Int(nullable: false));
            DropColumn("dbo.Designations", "DesignationName");
            AddPrimaryKey("dbo.EmployeeAttendance", "Id");
        }
    }
}
