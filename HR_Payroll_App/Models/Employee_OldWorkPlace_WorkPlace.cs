using HR_Payroll_App.Models.ClassModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models
{
    public class Employee_OldWorkPlace_WorkPlace
    {
        public Employee Employee { get; set; }
        public WorkPlace GetWorkPlace { get; set; }
        public OldWorkPlace GetOldWorkPlace { get; set; }
        public List<SelectListItem> Branches {get;set;}
        public List<SelectListItem> Departments { get; set; }
        public List<WorkPlace_Model> workPlace_Models { get; set; }
    }
}
