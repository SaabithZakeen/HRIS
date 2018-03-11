namespace HRIS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Login : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "UserLoginId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employee", "UserLoginId");
            AddForeignKey("dbo.Employee", "UserLoginId", "dbo.UserProfile", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "UserLoginId", "dbo.UserProfile");
            DropIndex("dbo.Employee", new[] { "UserLoginId" });
            DropColumn("dbo.Employee", "UserLoginId");
        }
    }
}
