using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HR_Payroll_App.Extension;
using HR_Payroll_App.Models;
using HR_Payroll_App.Models.ClassModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HR_Payroll_App.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public Payroll_DbContext context;
        public IHostingEnvironment environment;
        public AdminController(Payroll_DbContext _context, IHostingEnvironment _environment)
        {
            context = _context;
            environment = _environment;
        }

        public IActionResult AddDepartment()
        {
            ViewBag.Holdings = context.Holdings
                                       .Select(x => new SelectListItem {Text = x.Name, Value = x.Id.ToString()});

            ViewBag.Departments = context.Departments
                                          .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return View();
        }


        [HttpPost]
        public IActionResult AddDepartment(int? Id , CompanyDepartment CompanyDepartment)
        {
            if (Id.HasValue)
            {
                var companies = context.Companies
                                        .Where(x => x.HoldingId == Id.Value)
                                        .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });

                return PartialView("CompanySelect", companies);
            }

            context.CompanyDepartments.Add(CompanyDepartment);
            context.SaveChanges();

            return RedirectToAction("AddDepartment", "Admin");
        }


        public IActionResult AddEmployee()
        {
            ViewBag.Holdings = context.Holdings.Select(x => new SelectListItem { Text=x.Name, Value=x.Id.ToString() }).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult GetSelect(int? Id, int? companyId, int? company_Id, int? departmentId)
        {
            if (Id.HasValue)
            {
                var companies = context.Companies.Where(x => x.HoldingId == Id.Value).Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });

                return PartialView("CompanySelect", companies);
            }
            else if (companyId.HasValue)
            {

                var branches = context.Branches.Where(x => x.CompanyId == companyId.Value)
                                                .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

                return PartialView("CompanySelect", branches);
            }
            else if (company_Id.HasValue)
            {
                List<SelectListItem> departments = new List<SelectListItem>();

                var department_Id = context.CompanyDepartments.Where(x => x.CompanyId == company_Id.Value)
                                            .Select(x => x.DepartmentId);

                foreach (int item in department_Id)
                {
                    var items = context.GetWorkPlaceSelect<Department>(item);
                    departments.AddRange(items);
                }
                return PartialView("CompanySelect", departments);
            }
            else if (departmentId.HasValue)
            {
                var positions = context.GetWorkPlaceSelect<Position>(departmentId.Value);

                return PartialView("CompanySelect", positions);
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee_WorkPlaceModel employee_WorkPlaceModel , IFormFile file)
        {
            string FilePath = Path.Combine(environment.ContentRootPath, "Images");

            string fileFormat = file.FileName.Substring(file.FileName.LastIndexOf(".") + 1);

            string FileName = employee_WorkPlaceModel.Employee.Name + "_" + employee_WorkPlaceModel.Employee.Surname + "." + fileFormat;

            string FullPath = Path.Combine(FilePath, FileName);

            using (var stream = new FileStream(FullPath, FileMode.OpenOrCreate))
            {
                file.CopyTo(stream);
            }

            employee_WorkPlaceModel.Employee.Photo = FileName;


            context.Employees.Add(employee_WorkPlaceModel.Employee);
            context.SaveChanges();

            employee_WorkPlaceModel.WorkPlace.EmployeeId = employee_WorkPlaceModel.Employee.Id;

            context.WorkPlaces.Add(employee_WorkPlaceModel.WorkPlace);
            context.SaveChanges();

            return View();
        }
    }
}