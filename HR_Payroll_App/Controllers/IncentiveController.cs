using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_Payroll_App.Models;
using HR_Payroll_App.Models.ClassModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR_Payroll_App.Controllers
{
    [Authorize(Roles = "DepartmentHead")]
    public class IncentiveController : Controller
    {
        public Payroll_DbContext context;
        public SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public IncentiveController(Payroll_DbContext _context, SignInManager<AppUser> _signInManager, UserManager<AppUser> _userManager)
        {
            context = _context;
            signInManager = _signInManager;
            userManager = _userManager;
        }
                          
        public async Task<IActionResult> List(int? PageIndex)
        {
            List<EmployeeWorkplacePositionFullModel> empl = new List<EmployeeWorkplacePositionFullModel>();

            AppUser user = await userManager.FindByNameAsync(User.Identity.Name);

            var DepartmentId_CompanyId = await context.WorkPlaces.Where(x => x.EmployeeId == user.EmployeeId && x.ExitDate == null)
                                                     .Select(x =>new { x.Branch.CompanyId , x.Position.DepartmentId } )
                                                      .FirstOrDefaultAsync();

            var employeeId = context.WorkPlaces
                                    .Where(x => 
                                            x.Branch.CompanyId == DepartmentId_CompanyId.CompanyId
                                            && x.Position.DepartmentId == DepartmentId_CompanyId.DepartmentId
                                            && x.ExitDate == null)
                                   .Select(x => x.EmployeeId);

            foreach (var item in employeeId)
            {
                var employees = await context.Employees.Where(x => x.Id == item)
                                .Join(context.WorkPlaces.Where(w => w.ExitDate == null), e => e.Id, w => w.EmployeeId, (employee, workplace) => new { employee, workplace })
                                .Join(context.Branches, x => x.workplace.BranchId, b => b.Id, (x, b) => new { x, b })
                                .Join(context.Companies, v => v.b.CompanyId, c => c.Id, (v, c) => new { v, c })
                                .Join(context.Positions, t => t.v.x.workplace.PositionId, p => p.Id, (model, position) => new { model, position })
                                .Join(context.Departments, z => z.position.DepartmentId, d => d.Id, (z, department) =>
                                       new EmployeeWorkplacePositionFullModel
                                       {
                                           E_id = z.model.v.x.employee.Id,
                                           Ename = z.model.v.x.employee.Name,
                                           Surname = z.model.v.x.employee.Surname,
                                           FatherName = z.model.v.x.employee.FatherName,
                                           workplaceId = z.model.v.x.workplace.Id,
                                           Bonuses = z.model.v.x.employee.Bonuses.Where(x => x.EmployeeId == z.model.v.x.employee.Id).ToList(),
                                           Penalties = z.model.v.x.employee.Penalties.Where(x=>x.EmployeeId == z.model.v.x.employee.Id).ToList(),
                                           EntryDate = z.model.v.x.workplace.EntryDate,
                                           BranchName = z.model.v.b.Name,
                                           IsHead = z.model.v.b.IsHead,
                                           CompanyName = z.model.c.Name,
                                           PositionName = z.position.Namme,
                                           DepartmentName = department.Name
                                       }).ToListAsync();
                empl.AddRange(employees);
            }

            int Page = 2;

            Employee_Incentive_Model Employee_Incentive_Model = new Employee_Incentive_Model
            {
                EmployeeWorkplacePositionFullModel = Pagination<EmployeeWorkplacePositionFullModel>.Create(empl, PageIndex ?? 1, Page),
                Pagination = Pagination<EmployeeWorkplacePositionFullModel>.Create(empl, PageIndex ?? 1, Page),
                Month = DateTime.Now.Month,
                Year = DateTime.Now.Year,
                Days = Enumerable.Range(1, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)).ToList()
            };
    
            return View(Employee_Incentive_Model);
        }

        [HttpPost]
        public async Task<IActionResult> List(string Name, int? Month, int? Year, int? PageIndex)
        {
            List<EmployeeWorkplacePositionFullModel> empl = new List<EmployeeWorkplacePositionFullModel>();

            AppUser user = await userManager.FindByNameAsync(User.Identity.Name);

            var DepartmentId_CompanyId = await context.WorkPlaces.Where(x => x.EmployeeId == user.EmployeeId && x.ExitDate == null)
                                                     .Select(x => new { x.Branch.CompanyId, x.Position.DepartmentId })
                                                      .FirstOrDefaultAsync();

            var employeeId = context.WorkPlaces
                                    .Where(x =>
                                            x.Branch.CompanyId == DepartmentId_CompanyId.CompanyId
                                            && x.Position.DepartmentId == DepartmentId_CompanyId.DepartmentId
                                            && x.ExitDate == null)
                                   .Select(x => x.EmployeeId);


            foreach (var item in employeeId)
            {
                if (String.IsNullOrEmpty(Name))
                {
                    var employees = await context.Employees.Where(x => x.Id == item)
                                .Join(context.WorkPlaces.Where(w => w.ExitDate == null), e => e.Id, w => w.EmployeeId, (employee, workplace) => new { employee, workplace })
                                .Join(context.Branches, x => x.workplace.BranchId, b => b.Id, (x, b) => new { x, b })
                                .Join(context.Companies, v => v.b.CompanyId, c => c.Id, (v, c) => new { v, c })
                                .Join(context.Positions, t => t.v.x.workplace.PositionId, p => p.Id, (model, position) => new { model, position })
                                .Join(context.Departments, z => z.position.DepartmentId, d => d.Id, (z, department) =>
                                       new EmployeeWorkplacePositionFullModel
                                       {
                                           E_id = z.model.v.x.employee.Id,
                                           Ename = z.model.v.x.employee.Name,
                                           Surname = z.model.v.x.employee.Surname,
                                           FatherName = z.model.v.x.employee.FatherName,
                                           workplaceId = z.model.v.x.workplace.Id,
                                           EntryDate = z.model.v.x.workplace.EntryDate,
                                           Bonuses = z.model.v.x.employee.Bonuses.Where(x => x.EmployeeId == z.model.v.x.employee.Id).ToList(),
                                           Penalties = z.model.v.x.employee.Penalties.Where(x => x.EmployeeId == z.model.v.x.employee.Id).ToList(),
                                           BranchName = z.model.v.b.Name,
                                           IsHead = z.model.v.b.IsHead,
                                           CompanyName = z.model.c.Name,
                                           PositionName = z.position.Namme,
                                           DepartmentName = department.Name
                                       }).ToListAsync();
                    empl.AddRange(employees);
                }
                else
                {
                    var employees = await context.Employees.Where(x => x.Id == item && x.Name.StartsWith(Name))
                                .Join(context.WorkPlaces.Where(w => w.ExitDate == null), e => e.Id, w => w.EmployeeId, (employee, workplace) => new { employee, workplace })
                                .Join(context.Branches, x => x.workplace.BranchId, b => b.Id, (x, b) => new { x, b })
                                .Join(context.Companies, v => v.b.CompanyId, c => c.Id, (v, c) => new { v, c })
                                .Join(context.Positions, t => t.v.x.workplace.PositionId, p => p.Id, (model, position) => new { model, position })
                                .Join(context.Departments, z => z.position.DepartmentId, d => d.Id, (z, department) =>
                                       new EmployeeWorkplacePositionFullModel
                                       {
                                           E_id = z.model.v.x.employee.Id,
                                           Ename = z.model.v.x.employee.Name,
                                           Surname = z.model.v.x.employee.Surname,
                                           FatherName = z.model.v.x.employee.FatherName,
                                           workplaceId = z.model.v.x.workplace.Id,
                                           EntryDate = z.model.v.x.workplace.EntryDate,
                                           Bonuses = z.model.v.x.employee.Bonuses.Where(x => x.EmployeeId == z.model.v.x.employee.Id).ToList(),
                                           Penalties = z.model.v.x.employee.Penalties.Where(x => x.EmployeeId == z.model.v.x.employee.Id).ToList(),
                                           BranchName = z.model.v.b.Name,
                                           IsHead = z.model.v.b.IsHead,
                                           CompanyName = z.model.c.Name,
                                           PositionName = z.position.Namme,
                                           DepartmentName = department.Name
                                       }).ToListAsync();
                    empl.AddRange(employees);
                }

            }

            IEnumerable<int> days = Enumerable.Range(1, DateTime.DaysInMonth(Year ?? DateTime.Now.Year, Month ?? DateTime.Now.Month));

            int Page = 2;


            Employee_Incentive_Model Employee_Incentive_Model = new Employee_Incentive_Model
            {
                EmployeeWorkplacePositionFullModel = Pagination<EmployeeWorkplacePositionFullModel>.Create(empl, PageIndex ?? 1, Page),
                Pagination = Pagination<EmployeeWorkplacePositionFullModel>.Create(empl, PageIndex ?? 1, Page),
                Month = Month ?? DateTime.Now.Month,
                Year = Year ?? DateTime.Now.Year,
                Days = days.ToList()
            };


            return View(Employee_Incentive_Model);
        }

        [HttpPost]
        public IActionResult AddBonus(BonusModel bonusModel)
        {
            if (ModelState.IsValid)
            {
                Bonus bonus = new Bonus
                {
                    Date = bonusModel.Date,
                    EmployeeId = bonusModel.EmployeeId,
                     Amount = bonusModel.Amount,
                     Reason = bonusModel.Reason
                };

                context.Bonus.AddAsync(bonus);
                context.SaveChangesAsync();

                return RedirectToAction("List");
            }

            return View();
        }

        [HttpPost]
        public IActionResult AddPenalty(PenaltyModel penaltyModel)
        {
            if (ModelState.IsValid)
            {
                Penalty penalty = new Penalty
                {
                    Date = penaltyModel.Date,
                    EmployeeId = penaltyModel.EmployeeId,
                    Amount = penaltyModel.Amount,
                    Reason = penaltyModel.Reason
                };

                context.Penalties.AddAsync(penalty);
                context.SaveChangesAsync();

                return RedirectToAction("List");
            }

            return View();
        }


    }
}