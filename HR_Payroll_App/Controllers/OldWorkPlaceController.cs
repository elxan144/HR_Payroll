using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_Payroll_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR_Payroll_App.Controllers
{
    [Authorize]
    public class OldWorkPlaceController : Controller
    {
        public Payroll_DbContext context;
        public OldWorkPlaceController(Payroll_DbContext _context)
        {
            context = _context;
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}