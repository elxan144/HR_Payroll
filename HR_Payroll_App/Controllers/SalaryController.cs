using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_Payroll_App.Extension;
using HR_Payroll_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HR_Payroll_App.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SalaryController : Controller
    {
        public Payroll_DbContext context;

        public SalaryController(Payroll_DbContext _context)
        {
            context = _context;
        }

        [HttpPost]
        public IActionResult GetSelect(int? Id, int? companyId, int? departmentId)
        {
            if (Id.HasValue)
            {
                var companies = context.GetWorkPlaceSelect<Company>(Id.Value);

                return PartialView("CompanySelect", companies);
            }
            if (companyId.HasValue)
            {
                List<SelectListItem> departments = new List<SelectListItem>();

                var department_Id = context.CompanyDepartments.Where(x => x.CompanyId == companyId.Value)
                                            .Select(x => x.DepartmentId);

                foreach (int item in department_Id)
                {
                    var items = context.GetWorkPlaceSelect<Department>(item);
                    departments.AddRange(items);
                }
                return PartialView("CompanySelect", departments);
            }
            if (departmentId.HasValue)
            {
                var positions = context.GetWorkPlaceSelect<Position>(departmentId.Value);

                return PartialView("CompanySelect", positions);
            }

            return View();
        }

        public IActionResult Create()
        {
            ViewBag.Holdings = context.Holdings
                                       .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return View();
        }

       
        [HttpPost]
        public IActionResult Create(Salary salary)
        {
            ViewBag.Holdings = context.Holdings
                                       .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });

            context.Salaries.Add(salary);
            context.SaveChanges();
            return View();
        }

    }
}