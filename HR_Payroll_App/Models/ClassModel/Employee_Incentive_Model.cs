using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models.ClassModel
{
    public class Employee_Incentive_Model
    {
        public List<EmployeeWorkplacePositionFullModel> EmployeeWorkplacePositionFullModel { get; set; }
        public BonusModel BonusModel { get; set; }
        public PenaltyModel PenaltyModel { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public List<int> Days { get; set; }
        public Pagination<EmployeeWorkplacePositionFullModel> Pagination { get; set; }
    }
}
