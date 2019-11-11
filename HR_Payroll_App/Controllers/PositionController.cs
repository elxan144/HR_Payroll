using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_Payroll_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HR_Payroll_App.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PositionController : Controller
    {
        public Payroll_DbContext context;

        public PositionController(Payroll_DbContext _context)
        {
            context = _context;
        }

        public IActionResult Create()
        {
            ViewBag.Departments = context.Departments.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return View();
        }

        [HttpPost]
        public IActionResult Create(Position position)
        {
            ViewBag.Departments = context.Departments.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            context.Positions.Add(position);
            context.SaveChanges();
            return View();
        }
    }
}