namespace HRIS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatype_change : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employee", "TravelTime", c => c.String());
            AlterColumn("dbo.Qualification", "QualificationYear", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Qualification", "QualificationYear", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employee", "TravelTime", c => c.DateTime(nullable: false));
        }
    }
}
