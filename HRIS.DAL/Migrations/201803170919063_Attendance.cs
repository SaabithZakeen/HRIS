namespace HRIS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Attendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendance",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        InTime = c.String(),
                        OutTime = c.String(),
                        LateIn = c.String(),
                        LateOut = c.String(),
                        EarlyIn = c.String(),
                        EarlyOut = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Attendance");
        }
    }
}
