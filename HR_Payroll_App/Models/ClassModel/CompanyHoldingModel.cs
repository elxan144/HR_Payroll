using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models.ClassModel
{
    public class CompanyHoldingModel
    {
        public IEnumerable<SelectListItem> Holdings { get; set; }
        public IEnumerable<SelectListItem> Companies { get; set; }
    }
}
