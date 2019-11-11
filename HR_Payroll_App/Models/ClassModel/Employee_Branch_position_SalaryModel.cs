using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models.ClassModel
{
    public class Employee_Branch_position_SalaryModel
    {
        public int E_Id { get; set; }
        public string E_name { get; set; }
        public string E_surname { get; set; }
        public string BranchName { get; set; }
        public decimal  Salary { get; set; }
        public string PositionName { get; set; }
        public bool Selected { get; set; }
        public decimal TotalSalary { get; set; }
    }
}