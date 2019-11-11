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
    public class BranchController : Controller
    {
        public Payroll_DbContext context;

        public BranchController(Payroll_DbContext _context)
        {
            context = _context;
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.companies = await context.Companies.ToListAsync();
            return View();
        }
    
        [HttpPost]
        public async Task<IActionResult> Create(Branch branch)
        {
            ViewBag.companies = await context.Companies.ToListAsync();
            await context.Branches.AddAsync(branch);
            await context.SaveChangesAsync();
            return View();
        }

    }
}