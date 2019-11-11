using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_Payroll_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR_Payroll_App.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HoldingController : Controller
    {
        public Payroll_DbContext context;

        public HoldingController(Payroll_DbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string Name)
        {
            Holding holding = null;
            if (Name != null)
            {
                holding = new Holding() { Name = Name };
            }
            await context.Holdings.AddAsync(holding);
            await context.SaveChangesAsync();
            return View();
        }
    }
}