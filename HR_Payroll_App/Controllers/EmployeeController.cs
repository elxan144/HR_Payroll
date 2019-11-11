using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HR_Payroll_App.Extension;
using HR_Payroll_App.Models;
using HR_Payroll_App.Models.ClassModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HR_Payroll_App.Controllers
{
    public class EmployeeController : Controller
    {
        public Payroll_DbContext context;
        public IHostingEnvironment environment;
        public SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public EmployeeController(Payroll_DbContext _context , IHostingEnvironment _environment , SignInManager<AppUser> _signInManager, UserManager<AppUser> _userManager)
        {
            context = _context;
            environment = _environment;
            signInManager = _signInManager;
            userManager = _userManager;
        }

        [HttpGet]
        public async Task<IActionResult> List(int? PageIndex)
        {

            List<Employee> empl = new List<Employee>();


            AppUser user = await userManager.FindByNameAsync(User.Identity.Name);

            int companyId = await context.WorkPlaces.Where(x => x.EmployeeId == user.EmployeeId && x.ExitDate == null).Select(x => x.Branch.CompanyId).FirstOrDefaultAsync();

            var employeeId = context.WorkPlaces.Where(x => x.Branch.CompanyId == companyId && x.ExitDate == null).Select(x => x.EmployeeId);

            foreach (var item in employeeId)
            {
                var employees = context.Employees.Where(x => x.Id == item).Select(x => x);
                empl.AddRange(employees);
            }

            int Page = 8;

            EmployeeModel emp = new EmployeeModel
            {
                Employees = Pagination<Employee>.Create(empl, PageIndex ?? 1, Page),
                Pagination = Pagination<Employee>.Create(empl, PageIndex ?? 1, Page)
            };

            return View(emp);
        }

        [HttpPost]
        public async Task<IActionResult> List(int? PageIndex, int? Name)
        {

            List<Employee> empl = new List<Employee>();


            AppUser user = await userManager.FindByNameAsync(User.Identity.Name);

            int companyId = await context.WorkPlaces.Where(x => x.EmployeeId == user.EmployeeId && x.ExitDate == null).Select(x => x.Branch.CompanyId).FirstOrDefaultAsync();

            var employeeId = context.WorkPlaces.Where(x => x.Branch.CompanyId == companyId && x.ExitDate == null).Select(x => x.EmployeeId);

            foreach (var item in employeeId)
            {
                var employees = context.Employees.Where(x => x.Id == item).Select(x => x);
                empl.AddRange(employees);
            }
            int Page = 8;

            EmployeeModel emp = new EmployeeModel
            {
                Employees = Pagination<Employee>.Create(empl, PageIndex ?? 1, Page),
                Pagination = Pagination<Employee>.Create(empl, PageIndex ?? 1, Page)
            };

            return View(emp);
        }

        public async Task<IActionResult> Create()
        {
            List<SelectListItem> departments = new List<SelectListItem>();
            AppUser user = await userManager.FindByNameAsync(User.Identity.Name);

            int companyId = await context.WorkPlaces.Where(x => x.EmployeeId == user.EmployeeId).Select(x => x.Branch.CompanyId).FirstOrDefaultAsync();

           ViewBag.Branches = context.Branches.Where(x => x.CompanyId == companyId).Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            var departmentId = context.CompanyDepartments
                .Where(x => x.CompanyId == companyId)
                .Select(x => x.DepartmentId);

            foreach (var item in departmentId)
            {
              var _departments = context.Departments.Where(x => x.Id == item).Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

                departments.AddRange(_departments);
            }

            ViewBag.Departments = departments;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee_WorkPlaceModel employee_workplace, IFormFile file)
        {
            string FilePath = Path.Combine(environment.ContentRootPath,"Images");

            string fileFormat=file.FileName.Substring(file.FileName.LastIndexOf(".")+1);

            string FileName = employee_workplace.Employee.Name + "_" + employee_workplace.Employee.Surname + "." + fileFormat;
            
            string FullPath = Path.Combine(FilePath,FileName);

            using (var stream = new FileStream(FullPath, FileMode.OpenOrCreate))
            {
                file.CopyTo(stream);
            }

            employee_workplace.Employee.Photo = FileName;

            await context.Employees.AddAsync(employee_workplace.Employee);
            await context.SaveChangesAsync();

            employee_workplace.WorkPlace.EmployeeId = employee_workplace.Employee.Id;

            await context.WorkPlaces.AddAsync(employee_workplace.WorkPlace);
            await context.SaveChangesAsync();

            return RedirectToAction("List", "Employee");
        }

      
        public async Task<IActionResult> Profile(int id)
        {
            List<SelectListItem> departments = new List<SelectListItem>();
            AppUser user = await userManager.FindByNameAsync(User.Identity.Name);

            int companyId = await context.WorkPlaces.Where(x => x.EmployeeId == user.EmployeeId).Select(x => x.Branch.CompanyId).FirstOrDefaultAsync();

            var departmentId = context.CompanyDepartments
                .Where(x => x.CompanyId == companyId)
                .Select(x => x.DepartmentId);

            foreach (var item in departmentId)
            {
                var _departments = context.Departments.Where(x => x.Id == item).Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

                departments.AddRange(_departments);
            }

            Employee employe = context.Employees.Include(x => x.OldWorkPlaces).Include(x => x.WorkPlaces).Where(x => x.Id == id).Select(x => x).FirstOrDefault();

           var WorkplaceModel = context.WorkPlaces.Where(x=>x.EmployeeId == id)
                .Join(context.Positions, w => w.PositionId, p => p.Id, (w, p) => new { w.Id, w.BranchId, w.EntryDate, w.ExitDate, p.Namme, p.DepartmentId })
                .Join(context.Branches, w => w.BranchId, b => b.Id, (w, b) => new { w.DepartmentId, w.Id, w.EntryDate, w.ExitDate, w.Namme, b.Name })
                .Join(context.Departments, w => w.DepartmentId, d => d.Id,
                (w,d) => new WorkPlace_Model
                { EntryDate= w.EntryDate, ExitDate=w.ExitDate,  Id=w.Id, BranchName=w.Name, PositionNamme= w.Namme, DepartmentName = d.Name }).ToList();


            Employee_OldWorkPlace_WorkPlace employee_OldWorkPlace_WorkPlace = new Employee_OldWorkPlace_WorkPlace()
            {
                Employee = employe,
                Branches = context.Branches.Where(x => x.CompanyId == companyId).Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList(),
                Departments = departments,
                 workPlace_Models = WorkplaceModel
            };

            return View(employee_OldWorkPlace_WorkPlace);
        }

        [HttpPost]
        public IActionResult GetSelect(int? departmentId)
        {
             if (departmentId.HasValue)
            {
                var positions = context.GetWorkPlaceSelect<Position>(departmentId.Value);

                return PartialView("CompanySelect", positions);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OldWorkPlace(Employee_OldWorkPlace_WorkPlace oldWorkPlace)
        {            
            if (ModelState.IsValid)
            {
                context.OldWorkPlaces.Add(oldWorkPlace.GetOldWorkPlace);
               await context.SaveChangesAsync();
               
                return RedirectToAction("Profile", new { id = oldWorkPlace.GetOldWorkPlace.EmployeeId });
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WorkPlace(Employee_OldWorkPlace_WorkPlace _workplace)
        {
            if (ModelState.IsValid)
            {
                context.WorkPlaces.Add(_workplace.GetWorkPlace);
                await context.SaveChangesAsync();

                return RedirectToAction("Profile",new {id =_workplace.GetWorkPlace.EmployeeId });
            }
            return View();
        }
        
        [HttpPost]
        public ActionResult<WorkPlace_Position_Branch_Model> Get_EditWorkPlace(int? id)
        {
            if (id.HasValue)
            {
                var sa = new JsonSerializerSettings();

                WorkPlace workPlace = context.WorkPlaces.Where(x => x.Id == id).Include(x => x.Position).Include(x => x.Branch).First();


                var department = context.Departments.Where(x => x.Id == workPlace.Position.DepartmentId).FirstOrDefault();

                WorkPlace_Position_Branch_Model workPlace_Position_Branch_Model = new WorkPlace_Position_Branch_Model
                {
                    BranchName = workPlace.Branch.Name,
                    Entry = workPlace.EntryDate,
                    PositionName = workPlace.Position.Namme,
                    DepartmentName = department.Name,
                    WorkPlaceId = workPlace.Id,
                    EmployeeId = workPlace.EmployeeId
                };

                return Json(workPlace_Position_Branch_Model, sa);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditWorkPlace(Employee_OldWorkPlace_WorkPlace employee_OldWorkPlace_WorkPlace)
        {

            if (ModelState.IsValid)
            {
                context.WorkPlaces.Update(employee_OldWorkPlace_WorkPlace.GetWorkPlace);
                context.SaveChanges();

                List<SelectListItem> departments = new List<SelectListItem>();
                AppUser user = await userManager.FindByNameAsync(User.Identity.Name);

                int companyId = await context.WorkPlaces.Where(x => x.EmployeeId == user.EmployeeId).Select(x => x.Branch.CompanyId).FirstOrDefaultAsync();

                var departmentId = context.CompanyDepartments
                  .Where(x => x.CompanyId == companyId)
                  .Select(x => x.DepartmentId);

                foreach (var item in departmentId)
                {
                    var _departments = context.Departments.Where(x => x.Id == item).Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

                    departments.AddRange(_departments);
                }


                var branches = context.Branches.Where(x => x.CompanyId == companyId).Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

                var employee = context.Employees.Include(x => x.OldWorkPlaces)
                                                       .Where(x => x.Id == employee_OldWorkPlace_WorkPlace.GetWorkPlace.EmployeeId).FirstOrDefault();


                var WorkplaceModel = context.WorkPlaces.Where(x => x.EmployeeId == employee_OldWorkPlace_WorkPlace.GetWorkPlace.EmployeeId)
                .Join(context.Positions, w => w.PositionId, p => p.Id, (w, p) => new { w.Id, w.BranchId, w.EntryDate, w.ExitDate, p.Namme, p.DepartmentId })
                .Join(context.Branches, w => w.BranchId, b => b.Id, (w, b) => new { w.DepartmentId, w.Id, w.EntryDate, w.ExitDate, w.Namme, b.Name })
                .Join(context.Departments, w => w.DepartmentId, d => d.Id,
                (w, d) => new WorkPlace_Model
                {
                    EntryDate = w.EntryDate,
                    ExitDate = w.ExitDate,
                    Id = w.Id,
                    BranchName = w.Name,
                    PositionNamme = w.Namme,
                    DepartmentName = d.Name
                }).ToList();


                employee_OldWorkPlace_WorkPlace.Employee = employee;
                employee_OldWorkPlace_WorkPlace.Departments = departments;
                employee_OldWorkPlace_WorkPlace.Branches = branches;
                employee_OldWorkPlace_WorkPlace.workPlace_Models = WorkplaceModel;

                return View("Profile", employee_OldWorkPlace_WorkPlace);
            }



            return View();          
        }




    }
}