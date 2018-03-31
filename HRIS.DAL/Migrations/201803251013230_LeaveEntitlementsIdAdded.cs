namespace HRIS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LeaveEntitlementsIdAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeLeaveEntitlement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeaveId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        LeavesAvailable = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
         ///   DropTable("dbo.LeaveEntitlement");
        }
        
        public override void Down()
        {
            //CreateTable(
            //    "dbo.LeaveEntitlement",
            //    c => new
            //        {
            //            LeaveId = c.Int(nullable: false, identity: true),
            //            EmployeeId = c.Int(nullable: false),
            //            LeavesAvailable = c.Int(nullable: false),
            //            Status = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.LeaveId);
            
            //DropTable("dbo.EmployeeLeaveEntitlement");
        }
    }
}
