namespace HRIS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "User", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "User");
        }
    }
}
