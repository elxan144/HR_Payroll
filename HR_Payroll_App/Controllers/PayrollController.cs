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
    [Authorize(Roles = "HR")]
    public class PayrollController : Controller
    {
        public Payroll_DbContext context;
        public SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public PayrollController(Payroll_DbContext _context, SignInManager<AppUser> _signInManager, UserManager<AppUser> _userManager)
        {
            context = _context;
            signInManager = _signInManager;
            userManager = _userManager;
        }
        
        public async Task<IActionResult> List()
        {

            List<Employee_Branch_position_SalaryModel> empl = new List<Employee_Branch_position_SalaryModel>();

            AppUser user = await userManager.FindByNameAsync(User.Identity.Name);

            int companyId = await context.WorkPlaces.Where(x => x.EmployeeId == user.EmployeeId).Select(x => x.Branch.CompanyId).FirstOrDefaultAsync();

            var employeeId = context.WorkPlaces.Where(x => x.Branch.CompanyId == companyId && x.ExitDate == null).Select(x => x.EmployeeId).ToList();

            foreach (var item in employeeId)
            {
              var worker =  context.Employees.Where(e => e.Id == item)
                        .Join(context.WorkPlaces.Where(w => w.ExitDate == null), e => e.Id, w => w.EmployeeId, (e, w) => new { e, w })
                        .Join(context.Branches, ew => ew.w.BranchId, b => b.Id, (ew, b) => new { ew, b })
                        .Join(context.Positions, ewb => ewb.ew.w.PositionId, p => p.Id, (ewb, p)=>new {ewb,p })
                        .Join(context.Salaries.Where(x=>x.CompanyId == companyId), ewbps=>ewbps.p.Id , s=>s.PositionId,(t,s)=>
                        new Employee_Branch_position_SalaryModel{
                             E_Id = t.ewb.ew.e.Id,
                          E_name = t.ewb.ew.e.Name,
                           E_surname = t.ewb.ew.e.Surname,
                          BranchName = t.ewb.b.Name,
                            Salary = s.Amount,
                           PositionName = t.p.Namme,
                        }).ToList();

                empl.AddRange(worker);
            }
            
            return View(empl);
        }


        [HttpPost]
        public async Task<IActionResult> Calculate(int[] Id)
        {

            //Dictionary<decimal,int> salaries = new Dictionary<decimal,int>(); 

            List<Payroll> payrolls = new List<Payroll>();
            Payroll payroll = null;

            for (int i = 0; i < Id.Length; i++)
            {
                int companyId = await context.WorkPlaces.Where(x => x.EmployeeId == Id[i]).Select(x => x.Branch.CompanyId).FirstOrDefaultAsync();

                //1ayliq vezife maawi
                decimal Amount = context.WorkPlaces.Where(w => w.ExitDate == null && w.EmployeeId == Id[i])
                             .Join(context.Branches, w => w.BranchId, b => b.Id, (w, b) => new { w, b })
                             .Join(context.Positions, wb => wb.w.PositionId, p => p.Id, (wb, p) => new { wb, p })
                             .Join(context.Salaries.Where(w => w.CompanyId == companyId), wbp => wbp.wb.w.PositionId, s => s.PositionId, (wbp, s) =>
                                    s.Amount
                                ).FirstOrDefault();


                decimal salary = 0;

                var workplace = context.WorkPlaces.Where(x => x.EmployeeId == Id[i]).Include(x => x.Position).Include(x => x.Branch).ToList();

                foreach (var item in workplace)
                {
                    if (item.ExitDate == null)
                    {
                        decimal _amount = context.Salaries.Where(s => s.CompanyId == item.Branch.CompanyId && s.PositionId == item.PositionId).Select(x => x.Amount).FirstOrDefault();

                        //Bonuslarin cemi
                        var bonus = await context.Bonus.Where(x => x.EmployeeId == Id[i] && x.Date.Month == DateTime.Now.Month && x.Date >= item.EntryDate).
                                                       Select(x => x.Amount).SumAsync();

                        //cerimelerin cemi
                        var penalty = await context.Penalties.Where(x => x.EmployeeId == Id[i] && x.Date.Month == DateTime.Now.Month && x.Date >= item.EntryDate).
                                                             Select(x => x.Amount).SumAsync();


                        var attendance = context.Attendances.Where(x => x.EmployeeId == Id[i] &&
                                                                        x.Permission == false &&
                                                                        x.Date.Month == DateTime.Now.Month &&
                                                                        x.Date >= item.EntryDate).
                                                             Select(x => x.Date).ToList();

                        //1 ayda gunlarin sayi
                        int daysCount = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

                        //1 gun maawi 
                        var Day_Amount = _amount / daysCount;

                        salary += item.EntryDate.Month == DateTime.Now.Month ? ((DateTime.Now.Day - item.EntryDate.Day - attendance.Count) * Day_Amount) + bonus - penalty :
                            ((DateTime.Now.Day - attendance.Count) * Day_Amount) + bonus - penalty;

                    }
                    else if (item.ExitDate.Value.Month == DateTime.Now.Month)
                    {
                        decimal _amount_ = context.Salaries.Where(s => s.CompanyId == item.Branch.CompanyId && s.PositionId == item.PositionId).Select(x => x.Amount).FirstOrDefault();

                        //Bonuslarin cemi
                        var bonus = await context.Bonus.Where(x => x.EmployeeId == Id[i] 
                                                                && x.Date.Month == DateTime.Now.Month 
                                                                && x.Date < item.ExitDate.Value).
                                                        Select(x => x.Amount).SumAsync();

                        //cerimelerin cemi
                        var penalty = await context.Penalties.Where(x => x.EmployeeId == Id[i]
                                                                     && x.Date.Month == DateTime.Now.Month
                                                                     && x.Date < item.ExitDate.Value).
                                                             Select(x => x.Amount).SumAsync();


                        var attendance = context.Attendances.
                                                 Where(x => x.EmployeeId == Id[i] && 
                                                            x.Permission == false && 
                                                            x.Date.Month == DateTime.Now.Month &&
                                                            x.Date < item.ExitDate.Value).
                                                 Select(x => x.Date).ToList();

                        //1 ayda gunlarin sayi
                        int daysCount = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

                        //1 gun maawi 
                        var Day_Amount = _amount_ / daysCount;

                        salary += ((item.ExitDate.Value.Day - attendance.Count) * Day_Amount) + bonus - penalty;

                    }
                }

                payroll = new Payroll
                {
                    EmployeeId = Id[i],
                    TotalSalary = salary,
                    Date = DateTime.Now
                };


                if (context.Payrolls.Where(x => x.EmployeeId == Id[i] && x.Date.Month == DateTime.Now.Month).FirstOrDefault() == null)
                {
                    context.Payrolls.Add(payroll);
                    await context.SaveChangesAsync();
                }
                //salaries.Add(salary, Id[i]);

                payrolls.Add(context.Payrolls.Include(x=>x.Employee).Where(x => x.EmployeeId == Id[i] && x.Date.Month == DateTime.Now.Month).FirstOrDefault());
            }
            return PartialView("TotalSalary",payrolls);
        }

    }
}