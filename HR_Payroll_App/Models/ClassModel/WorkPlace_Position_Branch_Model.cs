using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models.ClassModel
{
    public class WorkPlace_Position_Branch_Model
    {
        public DateTime Entry { get; set; }
        public string  PositionName { get; set; }
        public string BranchName { get; set; }
        public string DepartmentName { get; set; }
        public int EmployeeId { get; set; }
        public int  WorkPlaceId { get; set; }
    }
}
