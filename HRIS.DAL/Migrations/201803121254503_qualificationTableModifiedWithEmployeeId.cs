namespace HRIS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qualificationTableModifiedWithEmployeeId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Qualification", "EmployeeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Qualification", "EmployeeId");
        }
    }
}
