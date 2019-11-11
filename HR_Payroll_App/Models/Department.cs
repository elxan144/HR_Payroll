using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Position> Positions { get; set; }

        public List<HoldingDepartment> HoldingDepartments { get; set; }

        public List<CompanyDepartment> CompanyDepartments { get; set; }
    }
}
