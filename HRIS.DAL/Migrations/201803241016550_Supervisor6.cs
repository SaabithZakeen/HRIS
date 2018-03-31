namespace HRIS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Supervisor6 : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("dbo.Attendance");
            CreateTable(
                "dbo.SupervisorSubordinateMap",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupervisorId = c.Int(nullable: false),
                        SubordinateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            //AddColumn("dbo.Attendance", "Id", c => c.Int(nullable: false, identity: true));
            //AddColumn("dbo.Attendance", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employee", "IsSupervisor", c => c.Boolean(nullable: false));
            //AlterColumn("dbo.Attendance", "EmployeeId", c => c.Int(nullable: false));
            //AddPrimaryKey("dbo.Attendance", "Id");
            //CreateIndex("dbo.Attendance", "EmployeeId");
            //AddForeignKey("dbo.Attendance", "EmployeeId", "dbo.Employee", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Attendance", "EmployeeId", "dbo.Employee");
            //DropIndex("dbo.Attendance", new[] { "EmployeeId" });
            //DropPrimaryKey("dbo.Attendance");
           // AlterColumn("dbo.Attendance", "EmployeeId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Employee", "IsSupervisor");
            //DropColumn("dbo.Attendance", "Status");
            //DropColumn("dbo.Attendance", "Id");
            DropTable("dbo.SupervisorSubordinateMap");
            //AddPrimaryKey("dbo.Attendance", "EmployeeId");
        }
    }
}
