using HRIS.DAL;
using HRIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using System.Web.Security;
using HRIS.Data.Models;


namespace HRIS.Controllers
{
    public class EmployeeProfileController : Controller
    {
        private HrisContext db = new HrisContext();

        // GET: EmployeeProfile
        public ActionResult Index()
        {
            var myDetails = db.Employee.Where(emp => emp.Id == MvcApplication.CurruntUserId).FirstOrDefault();

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

        [HttpGet]
        public ActionResult Edit(int EmployeeId)
        {
            ViewBag.DepartmenetList = new SelectList(from department in db.Departments.ToList().Where(c => c.Status == true) select department, "Id", "DepartmentName", 0);
            ViewBag.DesignationList = new SelectList(from designation in db.Designations.ToList().Where(v => v.Status == true) select designation, "Id", "Designation", 0);

            var employee = db.Employee.Where(emp => emp.Id == EmployeeId).FirstOrDefault();
            var departments = db.Departments.ToList();
            var designations = db.Designations.ToList();

            var employeeVm = new EmployeeViewModel();
            employeeVm.EmployeeId = employee.Id;
            employeeVm.EmployeeFirstName = employee.EmployeeFirstName;
            employeeVm.EmployeeLastName = employee.EmployeeLastName;
            employeeVm.EmployeeNameWithInitials = employee.EmployeeNameWithInitials;
            employeeVm.EmployeeAddress = employee.EmployeeAddress;
            employeeVm.PhoneNumber = employee.PhoneNumber;
            employeeVm.Status = employee.Status;
            employeeVm.Nic = employee.Nic;
            employeeVm.Email = employee.Email;
            employeeVm.DOJ = employee.DOJ;
            employeeVm.DateConfirmed = employee.DateConfirmed;
            employeeVm.EmploymentType = employee.EmploymentType;
            employeeVm.DOB = employee.DOB;
            employeeVm.MaritalStatus = employee.MaritalStatus;
            employeeVm.Gender = employee.Gender;
            employeeVm.TransportationMode = employee.TransportationMode;
            employeeVm.Distance = employee.Distance;
            employeeVm.TravelTime = employee.TravelTime;
            employeeVm.DistancePollingStation = employee.DistancePollingStation;
            employeeVm.PollingStationName = employee.PollingStationName;
            employeeVm.EmployeeDesignation = designations.Where(des => des.Id == employee.DesignationId).FirstOrDefault().Designation;
            employeeVm.EmployeeDepartment = departments.Where(des => des.Id == employee.DepartmentId).FirstOrDefault().DepartmentName;

            return View(employeeVm);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeViewModel employeeVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Employee employee = db.Employee.Where(emp => emp.Id == employeeVm.EmployeeId).FirstOrDefault();
                    employee.EmployeeFirstName = employeeVm.EmployeeFirstName;
                    employee.EmployeeLastName = employeeVm.EmployeeLastName;
                    employee.EmployeeNameWithInitials = employeeVm.EmployeeNameWithInitials;
                    employee.EmployeeAddress = employeeVm.EmployeeAddress;
                    employee.PhoneNumber = employeeVm.PhoneNumber;
                    employee.Status = true;
                    employee.Nic = employeeVm.Nic;
                    employee.Email = employeeVm.Email;
                    employee.DOJ = employeeVm.DOJ;
                    employee.DateConfirmed = employeeVm.DateConfirmed;
                    employee.EmploymentType = employeeVm.EmploymentType;
                    employee.DOB = employeeVm.DOB;
                    employee.MaritalStatus = employeeVm.MaritalStatus;
                    employee.Gender = employeeVm.Gender;
                    employee.TransportationMode = employeeVm.TransportationMode;
                    employee.Distance = employeeVm.Distance;
                    employee.TravelTime = employeeVm.TravelTime;
                    employee.DistancePollingStation = employeeVm.DistancePollingStation;
                    employee.PollingStationName = employeeVm.PollingStationName;
                    employee.DesignationId = employeeVm.Designations.Id;
                    employee.DepartmentId = employeeVm.Department.Id;


                    TryUpdateModel(employee, "EmployeeId,EmployeeFirstName,EmployeeLastName,EmployeeNameWithInitials,EmployeeAddress,PhoneNumber,Status,Nic,Email,DOJ,DateConfirmed,EmploymentType,DOB,MaritalStatus,Gender,TransportationMode,Distance,TravelTime,DistancePollingStation,PollingStationName,DesignationId,DepartmentId");
                    db.Employee.Add(employee);
                    db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ActionResult Edit()
        {
            return View();
        }

    }
}