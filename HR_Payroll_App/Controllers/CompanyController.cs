using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_Payroll_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR_Payroll_App.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CompanyController : Controller
    {
        public Payroll_DbContext context;

        public CompanyController(Payroll_DbContext _context)
        {
            context = _context;
        }

        public async Task<IActionResult> List()
        {
            List<Company> companies = await context.Companies.ToListAsync();
            return View(companies);
        }


        public async Task<IActionResult> Create()
        {
            List<Holding> holdings = await context.Holdings.ToListAsync();
            return View(holdings);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string Name, int HoldingId)
        {
            Company company = new Company()
            {
                Name = Name,
                HoldingId = HoldingId
            };

            await context.Companies.AddAsync(company);
            await context.SaveChangesAsync();

            return RedirectToAction("List");
        }




    }
}