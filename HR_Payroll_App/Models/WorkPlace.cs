using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models
{
    public class WorkPlace
    {
        public int Id { get; set; }
 
        [Required]
        public DateTime EntryDate { get; set; }
       
        public DateTime? ExitDate { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required]
        public int PositionId { get; set; }

        public Position Position { get; set; }

        [Required]
        public int BranchId { get; set; }

        public Branch Branch { get; set; }
    }
}
