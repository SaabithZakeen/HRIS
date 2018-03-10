using HRIS.DAL;
using HRIS.Data.Models;
using HRIS.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        private HrisContext db = new HrisContext();
        // GET: Employee
        public ActionResult Index()
        {
            var employees = db.Employee.Where(emp => emp.Status == true).ToList();
            var departments = db.Departments.ToList();
            var designations = db.Designations.ToList();

            var employeeVmList = new List<EmployeeViewModel>();
            foreach (var item in employees)
            {
                var employeeVm = new EmployeeViewModel();
                employeeVm.EmployeeId = item.Id;
                employeeVm.EmployeeFirstName = item.EmployeeFirstName;
                employeeVm.EmployeeLastName = item.EmployeeLastName;
                employeeVm.EmployeeNameWithInitials = item.EmployeeNameWithInitials;
                employeeVm.EmployeeAddress = item.EmployeeAddress;
                employeeVm.PhoneNumber = item.PhoneNumber;
                employeeVm.Status = item.Status;
                employeeVm.Nic = item.Nic;
                employeeVm.Email = item.Email;
                employeeVm.DOJ = item.DOJ;
                employeeVm.DateConfirmed = item.DateConfirmed;
                employeeVm.EmploymentType = item.EmploymentType;
                employeeVm.DOB = item.DOB;
                employeeVm.MaritalStatus = item.MaritalStatus;
                employeeVm.Gender = item.Gender;
                employeeVm.TransportationMode = item.TransportationMode;
                employeeVm.Distance = item.Distance;
                employeeVm.TravelTime = item.TravelTime;
                employeeVm.DistancePollingStation = item.DistancePollingStation;
                employeeVm.PollingStationName = item.PollingStationName;
                employeeVm.EmployeeDesignation = designations.Where(des => des.Id == item.DesignationId).FirstOrDefault().Designation;
                employeeVm.EmployeeDepartment = departments.Where(dep => dep.Id == item.DepartmentId).FirstOrDefault().DepartmentName;

                employeeVmList.Add(employeeVm);
            }

            return View(employeeVmList);
        }
        [HttpGet]
		public ActionResult Add()
		{
			ViewBag.DepartmentList = new SelectList(from department in db.Departments.ToList().Where(c => c.Status == true) select department, "Id", "DepartmentName", 0);
			ViewBag.DesignationList = new SelectList(from designation in db.Designations.ToList().Where(v => v.Status == true) select designation, "Id", "Designation", 0);
			return View();
		}

		[HttpPost]
		public ActionResult Add(EmployeeViewModel employeeVm)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var employee = new Employee();
                    employee.Id=employeeVm.EmployeeId;
                    employee.EmployeeFirstName = employeeVm.EmployeeFirstName;
                    employee.EmployeeLastName=employeeVm.EmployeeLastName;
                    employee.EmployeeNameWithInitials=employeeVm.EmployeeNameWithInitials;
                    employee.EmployeeAddress=employeeVm.EmployeeAddress;
                    employee.PhoneNumber=employeeVm.PhoneNumber;
                    employee.Status = true;
                    employee.Nic = "nic";
                    employee.Email=employeeVm.Email;
                    employee.DOJ=employeeVm.DOJ;
                    employee.DateConfirmed=employeeVm.DateConfirmed;
                    employee.EmploymentType=employeeVm.EmploymentType;
                    employee.DOB=employeeVm.DOB;
                    employee.MaritalStatus=employeeVm.MaritalStatus;
                    employee.Gender=employeeVm.Gender;
                    employee.TransportationMode =employeeVm.TransportationMode;
                    employee.Distance =employeeVm.Distance;
                    employee.TravelTime=employeeVm.TravelTime;
                    employee.DistancePollingStation=employeeVm.DistancePollingStation;
                    employee.PollingStationName = employeeVm.PollingStationName;
                    employee.DesignationId = employeeVm.Designations.Id;
                    employee.DepartmentId = employeeVm.Department.Id;


                    TryUpdateModel(employee, "EmployeeId,EmployeeFirstName,EmployeeLastName,EmployeeNameWithInitials,EmployeeAddress,PhoneNumber,Status,Nic,Email,DOJ,DateConfirmed,EmploymentType,DOB,MaritalStatus,Gender,TransportationMode,Distance,TravelTime,DistancePollingStation,PollingStationName,DesignationId,DepartmentId");
                    db.Employee.Add(employee);
                    db.Entry(employee).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }
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
                    var employee = new Employee();
                    employee.Id = employeeVm.EmployeeId;
                    employee.EmployeeFirstName = employeeVm.EmployeeFirstName;
                    employee.EmployeeLastName = employeeVm.EmployeeLastName;
                    employee.EmployeeNameWithInitials = employeeVm.EmployeeNameWithInitials;
                    employee.EmployeeAddress = employeeVm.EmployeeAddress;
                    employee.PhoneNumber = employeeVm.PhoneNumber;
                    employee.Status = true;
                    employee.Nic = "nic";
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
                    db.Entry(employee).State = System.Data.Entity.EntityState.Added;
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