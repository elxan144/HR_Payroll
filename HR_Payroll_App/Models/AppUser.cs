using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models
{
    public class AppUser : IdentityUser
    {
        public int? EmployeeId { get; set; }
    }
}