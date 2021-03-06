﻿using HRIS.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS.Areas.Admin.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string EmployeeFirstName { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string EmployeeLastName { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string EmployeeNameWithInitials { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string EmployeeAddress { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public int PhoneNumber { get; set; }

        public bool Status { get; set; }

        [Required(ErrorMessage = "Required field.")]
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

        public string TravelTime { get; set; }

        public int DistancePollingStation { get; set; }

        public string PollingStationName { get; set; }

        public string EmployeeDepartment { get; set; }

        public string EmployeeDesignation { get; set; }

        public int UserLoginId { get; set; }

        public string UserLoginName { get; set; }
        
        public string  UserLoginPassword { get; set;}

        public bool IsSupervisor { get; set; }

        public Departments Department { get; set; }

        public Designations Designations { get; set; }

        public UserProfile UserProfile { get; set; }
    }
}