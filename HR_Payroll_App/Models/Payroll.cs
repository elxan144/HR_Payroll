using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models
{
    public class Payroll
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public decimal Bonus { get; set; }
        public decimal Penalty { get; set; }
        public int Attendance { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalSalary { get; set; }
    }
}
