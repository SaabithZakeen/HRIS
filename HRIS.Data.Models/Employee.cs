using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Data.Models
{
	public class Employee
	{
        public int Id { get; set; }

        public string EmployeeFirstName { get; set; }

        public string EmployeeLastName { get; set; }

        public string EmployeeNameWithInitials { get; set; }

		public string EmployeeAddress { get; set; }

        public int PhoneNumber { get; set; }

        public bool Status { get; set; }

        public string Nic { get; set; }

        public string Email { get; set; }

        public DateTime DOJ { get; set; }

		public DateTime DateConfirmed { get; set; }

		public string EmploymentType { get; set; }

		public DateTime DOB { get; set; }

        public string MaritalStatus { get; set; }

        public string Gender { get; set; }

        public string TransportationMode { get; set; }

		public int Distance { get; set; }

		public DateTime TravelTime { get; set; }

		public int DistancePollingStation { get; set; }

		public string PollingStationName { get; set; }

        [ForeignKey("UserProfile")]
        public int UserLoginId { get; set; }

        [ForeignKey("Departments")]
		public int DepartmentId { get; set; }

		[ForeignKey("Designations")]
		public int DesignationId { get; set; }

		public Departments Departments { get; set; }

		public Designations Designations { get; set; }

        public UserProfile UserProfile { get; set; }

	}
}
