using HRIS.DAL;
using HRIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS.Controllers
{
    public class EmployeeProfileController : Controller
    {
        private HrisContext db = new HrisContext();

        // GET: EmployeeProfile
        public ActionResult Index()
        {
            var myDetails = db.Employee.Where(emp => emp.Id == MvcApplication.CurruntEmployeeId).FirstOrDefault();

            var departments = db.Departments.ToList();
            var designations = db.Designations.ToList();

            var employeeVm = new EmployeeViewModel();
            employeeVm.EmployeeId = myDetails.Id;
            employeeVm.EmployeeFirstName = myDetails.EmployeeFirstName;
            employeeVm.EmployeeLastName = myDetails.EmployeeLastName;
            employeeVm.EmployeeNameWithInitials = myDetails.EmployeeNameWithInitials;
            employeeVm.EmployeeAddress = myDetails.EmployeeAddress;
            employeeVm.PhoneNumber = myDetails.PhoneNumber;
            employeeVm.Status = myDetails.Status;
            employeeVm.Nic = myDetails.Nic;
            employeeVm.Email = myDetails.Email;
            employeeVm.DOJ = myDetails.DOJ;
            employeeVm.DateConfirmed = myDetails.DateConfirmed;
            employeeVm.EmploymentType = myDetails.EmploymentType;
            employeeVm.DOB = myDetails.DOB;
            employeeVm.MaritalStatus = myDetails.MaritalStatus;
            employeeVm.Gender = myDetails.Gender;
            employeeVm.TransportationMode = myDetails.TransportationMode;
            employeeVm.Distance = myDetails.Distance;
            employeeVm.TravelTime = myDetails.TravelTime;
            employeeVm.DistancePollingStation = myDetails.DistancePollingStation;
            employeeVm.PollingStationName = myDetails.PollingStationName;
            employeeVm.EmployeeDesignation = designations.Where(des => des.Id == myDetails.DesignationId).FirstOrDefault().Designation;
            employeeVm.EmployeeDepartment = departments.Where(des => des.Id == myDetails.DepartmentId).FirstOrDefault().DepartmentName;

            return View(employeeVm);
        }
    }
}