using HRIS.Areas.Admin.Models;
using HRIS.DAL;
using HRIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS.Areas.Admin.Controllers
{
    public class SupervisorController : Controller
    {
        private HrisContext db = new HrisContext();

        // GET: Admin/Supervisor
        public ActionResult Index()
        {
            var supervisors = db.Employee.Where(emp => emp.IsSupervisor == true && emp.Status == true).ToList();


            var supervisorList = new List<EmployeeViewModel>();
            foreach (var item in supervisors)
            {
                var employeeVm = new EmployeeViewModel();
                employeeVm.EmployeeId = item.Id;
                employeeVm.EmployeeFirstName = item.EmployeeFirstName;
                employeeVm.EmployeeLastName = item.EmployeeLastName;
                employeeVm.EmployeeNameWithInitials = item.EmployeeNameWithInitials;
                supervisorList.Add(employeeVm);
            }

            return View(supervisorList);
        }

        public ActionResult Edit(int id)
        {
            var subordinatesAndSupervisord = db.SupervisorSubordinateMap.Where(sup => sup.SupervisorId == id).ToList();
            var empList = new List<Employee>();

            foreach (var item in subordinatesAndSupervisord)
            {
                var employee = new Employee();
                employee = db.Employee.Where(emp => emp.Id == item.SubordinateId).FirstOrDefault();
                empList.Add(employee);
            }

            var employeeVmList = new List<EmployeeViewModel>();
            foreach (var item in empList)
            {
                var employeeVm = new EmployeeViewModel();
                employeeVm.EmployeeId = item.Id;
                employeeVm.EmployeeFirstName = item.EmployeeFirstName;
                employeeVm.EmployeeLastName = item.EmployeeLastName;
                employeeVm.EmployeeNameWithInitials = item.EmployeeNameWithInitials;
                employeeVmList.Add(employeeVm);
            }

            return View(employeeVmList);
        }

    }
}