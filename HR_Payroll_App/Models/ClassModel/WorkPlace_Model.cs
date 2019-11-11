using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models.ClassModel
{
    public class WorkPlace_Model
    {
        public int Id { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime? ExitDate { get; set; }

        public string PositionNamme { get; set; }

        public string BranchName { get; set; }

        public string DepartmentName { get; set; }
    }
}
