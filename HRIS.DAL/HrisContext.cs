using HRIS.Data.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HRIS.DAL
{
	public class HrisContext : DbContext
    {
        public HrisContext()
            : base("HrisContext")
        {
        }

		//      public DbSet<ExpirationPeriod> ExpirationPeriod { get; set; }
		//      public DbSet<Customers> Customers { get; set; }
		//      public DbSet<Projects> Projects { get; set; }
		//      public DbSet<PurchasedItems> PurchasedItems { get; set; }

        //public DbSet<webpages_Roles> webpages_Roles { get; set; }
        //public DbSet<webpages_UsersInRoles> webpages_UsersInRoles { get; set; }
        //public DbSet<UserProfile> UserProfile { get; set; }
        //public DbSet<webpages_Membership> webpages_Membership { get; set; }

		public DbSet<Departments> Departments { get; set; }

        public DbSet<Designations> Designations { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<WorkExperience> WorkExperience { get; set; }

        public DbSet<Qualification> Qualification { get; set; }

        public DbSet<ExpertiseProfile> ExpertiseProfile { get; set; }

        public DbSet<Dependants> Dependants { get; set; }

        public DbSet<BankDetails> BankDetails { get; set; }

        public DbSet<EmergencyContact> EmergencyContact { get; set; }

        public DbSet<Attendance> Attendance { get; set; }

        public DbSet<webpages_Roles> webpages_Roles { get; set; }
        public DbSet<webpages_UsersInRoles> webpages_UsersInRoles { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<webpages_Membership> webpages_Membership { get; set; }

		//public DbSet<EmailSettings> EmailSettings { get; set; }

		//public DbSet<Invoice> Invoice { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}

	}
}
