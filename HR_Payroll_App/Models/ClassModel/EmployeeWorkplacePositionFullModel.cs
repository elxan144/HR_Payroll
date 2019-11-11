using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models.ClassModel
{
    public class EmployeeWorkplacePositionFullModel
    {
        public int  E_id { get; set; }
        public string Ename { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public int workplaceId { get; set; }
        public DateTime EntryDate { get; set; }
        public string BranchName { get; set; }
        public bool IsHead { get; set; }
        public string CompanyName { get; set; }
        public string DepartmentName { get; set; }
        public string PositionName { get; set; }
        public List<Attendance> Attendances { get; set; }
        public List<Bonus> Bonuses { get; set; }
        public List<Penalty> Penalties { get; set; }
    }
}
