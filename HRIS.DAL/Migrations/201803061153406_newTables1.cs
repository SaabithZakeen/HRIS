namespace HRIS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newTables1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankDetails",
                c => new
                    {
                        BankId = c.Int(nullable: false, identity: true),
                        BankName = c.String(),
                        BranchName = c.String(),
                        AccountNo = c.Int(nullable: false),
                        NameGivenToBank = c.String(),
                        Salary = c.Int(nullable: false),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BankId);
            
            CreateTable(
                "dbo.Dependants",
                c => new
                    {
                        DependantId = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Nic = c.String(),
                        Nationality = c.String(),
                        Address = c.String(),
                        Gender = c.String(),
                        Telephone = c.Int(nullable: false),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DependantId);
            
            CreateTable(
                "dbo.EmergencyContact",
                c => new
                    {
                        EmergencyContactId = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Relationship = c.String(),
                        Nic = c.String(),
                        Address = c.String(),
                        Mobile = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmergencyContactId);
            
            CreateTable(
                "dbo.ExpertiseProfile",
                c => new
                    {
                        ExpertiseId = c.Int(nullable: false, identity: true),
                        ExpertiseArea = c.String(),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ExpertiseId);
            
            CreateTable(
                "dbo.Qualification",
                c => new
                    {
                        QualificationId = c.Int(nullable: false, identity: true),
                        QualificationType = c.String(),
                        QualificationName = c.String(),
                        Institute = c.String(),
                        QualificationYear = c.DateTime(nullable: false),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.QualificationId);
            
            CreateTable(
                "dbo.WorkExperience",
                c => new
                    {
                        WorkExperienceId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        ConfirmedDate = c.DateTime(nullable: false),
                        Department = c.String(),
                        DesignationWhenLeaving = c.String(),
                        ReasonForLeaving = c.String(),
                        Achievements = c.String(),
                        Accountabilities = c.String(),
                        PeriodServed = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.WorkExperienceId);
            
            AddColumn("dbo.Employee", "EmployeeFirstName", c => c.String());
            AddColumn("dbo.Employee", "EmployeeLastName", c => c.String());
            AddColumn("dbo.Employee", "EmployeeNameWithInitials", c => c.String());
            AlterColumn("dbo.Employee", "PhoneNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Employee", "EmployeFirstName");
            DropColumn("dbo.Employee", "EmployeLastName");
            DropColumn("dbo.Employee", "EmployeNameWithInitials");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "EmployeNameWithInitials", c => c.String());
            AddColumn("dbo.Employee", "EmployeLastName", c => c.String());
            AddColumn("dbo.Employee", "EmployeFirstName", c => c.String());
            AlterColumn("dbo.Employee", "PhoneNumber", c => c.String());
            DropColumn("dbo.Employee", "EmployeeNameWithInitials");
            DropColumn("dbo.Employee", "EmployeeLastName");
            DropColumn("dbo.Employee", "EmployeeFirstName");
            DropTable("dbo.WorkExperience");
            DropTable("dbo.Qualification");
            DropTable("dbo.ExpertiseProfile");
            DropTable("dbo.EmergencyContact");
            DropTable("dbo.Dependants");
            DropTable("dbo.BankDetails");
        }
    }
}
