using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int HoldingId { get; set; }

        public Holding Holding { get; set; }

        public List<Branch> Branches { get; set; }

        public List<Salary> Salaries { get; set; }

        public List<CompanyDepartment> CompanyDepartments { get; set; }
    }
}
