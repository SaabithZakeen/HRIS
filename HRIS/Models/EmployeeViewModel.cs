using HRIS.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS.Models
{
    public class EmployeeViewModel
    {
        [Key]
        public int EmployeeId { get; set; }

        [Display(Name="First Name")]
        public string EmployeeFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string EmployeeLastName { get; set; }

        [Display(Name = "Name With Initials")]
        public string EmployeeNameWithInitials { get; set; }

        [Display(Name = "Employee Address")]
        public string EmployeeAddress { get; set; }

        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }

        [Display(Name = "Nic")]
        public string Nic { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "DOJ")]
        public DateTime DOJ { get; set; }

        [Display(Name = "Date Confirmed")]
        public DateTime DateConfirmed { get; set; }

        [Display(Name = "Employment Type")]
        public string EmploymentType { get; set; }

        [Display(Name = "DOB")]
        public DateTime DOB { get; set; }

        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Transportation Mode")]
        public string TransportationMode { get; set; }

        [Display(Name = "Distance")]
        public int Distance { get; set; }

        [Display(Name = "Travel Time")]
        public string TravelTime { get; set; }

        [Display(Name = "Distance Polling Station")]
        public int DistancePollingStation { get; set; }

        [Display(Name = "PollingStation Name")]
        public string PollingStationName { get; set; }

        [Display(Name = "Department name")]
        public string EmployeeDepartment { get; set; }

        [Display(Name = "Designation")]
        public string EmployeeDesignation { get; set; }

        [Display(Name = "User Login Id")]
        public int UserLoginId { get; set; }

        [Display(Name = "User Login Name")]
        public string UserLoginName { get; set; }

        [Display(Name = "User Login Password")]
        public string  UserLoginPassword { get; set;}

        public Departments Department { get; set; }

        public Designations Designations { get; set; }

        public UserProfile UserProfile { get; set; }
    }
}