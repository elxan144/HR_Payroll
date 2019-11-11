using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Payroll_App.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public bool Permission { get; set; }
        [Required]
        public string Reason { get; set; }
        [Required]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
