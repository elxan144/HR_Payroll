using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models
{
    public class CompanyDepartment
    {
        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
