using HR_Payroll_App.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Components
{
    public class OldWorkPlaceViewComponent : ViewComponent
    {
        public Payroll_DbContext context;

        public OldWorkPlaceViewComponent(Payroll_DbContext context)
        {
            this.context = context;
        } 
    }
}
